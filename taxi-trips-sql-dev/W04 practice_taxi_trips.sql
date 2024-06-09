/*
Csinálj egy taxi_trips nevû adatbázist
*/
create database taxi_trips

/*
Ebben legyen egy stag_taxi_trips tábla a lenti mezõkkel:
trip_id                               object -> Primary key
taxi_id                               object
trip_start_timestamp          datetime64[ms]
trip_end_timestamp            datetime64[ms]
trip_seconds                           int64
trip_miles                           float64
pickup_community_area                  int64
fare                                 float64
tips                                 float64
tolls                                float64
extras                               float64
trip_total                           float64
payment_type                          object
company                               object
pickup_centroid_latitude              object
pickup_centroid_longitude             object
dropoff_community_area                 int64
dropoff_centroid_latitude             object
dropoff_centroid_longitude            object
*/

use taxi_trips

drop table if exists stag_taxi_trips;

create table stag_taxi_trips(
	trip_id nvarchar(40) not null constraint PK_stag_taxi_trips primary key (trip_id),
	taxi_id nvarchar(128) not null,
	trip_start_timestamp datetime not null,
	trip_end_timestamp datetime not null,
	trip_seconds int null,
	trip_miles decimal(10,4) null,
	pickup_community_area int null,
	dropoff_community_area int null,
	fare decimal(10,4) null,
	tips decimal(10,4) null,
	tolls decimal(10,4) null,
	extras decimal(10,4) null,
	trip_total decimal(10,4) null,
	payment_type nvarchar(50) null,
	company nvarchar(100) null,
	pickup_centroid_latitude nvarchar(100) null,
	pickup_centroid_longitude nvarchar(100) null,
	dropoff_centroid_latitude nvarchar(100) null,
	dropoff_centroid_longitude nvarchar(100) null
)


/*
Töltsük fel a táblát a csv-bõl.
Python adatexportja UTF-16 legyen, UTF8-al nem jó.
*/

bulk insert stag_taxi_trips
from 'D:\doc\learn\Database\Data Engineer\hobby-projects\taxi-trips-sql-dev\taxi_trips2024-04-09.csv'
with (
	firstrow = 2,
	fieldterminator = ';',
	ROWTERMINATOR = '\n',
	datafiletype = 'widechar',
	batchsize = 10000
)

/*
Készítsünk egy adatbázist a community areak-nak, ezt táblakonstruktorral töltsük fel.
area_id	int not null primary key
area_name nvarchar(100) not null 
*/

create table dbo.taxi_comm_area(
	area_id int not null constraint PK_taxi_comm_area primary key (area_id),
	area_name nvarchar(100) not null
)

--A táblakonstruktor létrehozása
drop table if exists #comm_area
select * 
into #comm_area 
from
(
	values
		(1,'Rogers Park'),
		(2,'West Ridge'),
		(3,'Uptown'),
		(4,'Lincoln Square'),
		(5,'North Center'),
		(6,'Lake View'),
		(7,'Lincoln Park'),
		(8,'Near North Side'),
		(9,'Edison Park'),
		(10,'Norwood Park'),
		(11,'Jefferson Park'),
		(12,'Forest Glen'),
		(13,'North Park'),
		(14,'Albany Park'),
		(15,'Portage Park'),
		(16,'Irving Park'),
		(17,'Dunning'),
		(18,'Montclare'),
		(19,'Belmont Cragin'),
		(20,'Hermosa'),
		(21,'Avondale'),
		(22,'Logan Square'),
		(23,'Humboldt Park'),
		(24,'West Town'),
		(25,'Austin'),
		(26,'West Garfield Park'),
		(27,'East Garfield Park'),
		(28,'Near West Side'),
		(29,'North Lawndale'),
		(30,'South Lawndale'),
		(31,'Lower West Side'),
		(32,'Loop'),
		(33,'Near South Side'),
		(34,'Armour Square'),
		(35,'Douglas'),
		(36,'Oakland'),
		(37,'Fuller Park'),
		(38,'Grand Boulevard'),
		(39,'Kenwood'),
		(40,'Washington Park'),
		(41,'Hyde Park'),
		(42,'Woodlawn'),
		(43,'South Shore'),
		(44,'Chatham'),
		(45,'Avalon Park'),
		(46,'South Chicago'),
		(47,'Burnside'),
		(48,'Calumet Heights'),
		(49,'Roseland'),
		(50,'Pullman'),
		(51,'South Deering'),
		(52,'East Side'),
		(53,'West Pullman'),
		(54,'Riverdale'),
		(55,'Hegewisch'),
		(56,'Garfield Ridge'),
		(57,'Archer Heights'),
		(58,'Brighton Park'),
		(59,'McKinley Park'),
		(60,'Bridgeport'),
		(61,'New City'),
		(62,'West Elsdon'),
		(63,'Gage Park'),
		(64,'Clearing'),
		(65,'West Lawn'),
		(66,'Chicago Lawn'),
		(67,'West Englewood'),
		(68,'Englewood'),
		(69,'Greater Grand Crossing'),
		(70,'Ashburn'),
		(71,'Auburn Gresham'),
		(72,'Beverly'),
		(73,'Washington Heights'),
		(74,'Mount Greenwood'),
		(75,'Morgan Park'),
		(76,'O Hare'),
		(77,'Edgewater')
) as #comm_area(area_id, area_name)

select * from #comm_area

--feltöltés
insert into taxi_comm_area(area_id, area_name)
select * from #comm_area

/*
Készítsünk két mapping táblát a cégeknek és a fizetési módnak 
map_companies
map_payments

company_id, payment_id int identity(1,1) Primary key not null
.._name nvarchar(100) not null

Töltsük fel a mapping táblákat a staging egyedi értékeivel

Készítsük el a taxi_trips fõtáblát (main_taxi_trips), itt a dropoff, pickup community area, a company és a payment type int típusú legyen.

Hozzunk létre egy-egy FK-t a mapping táblákhoz.

A stagingbõl töltsük át az adatokat merge-el.
-Ha nincs benne a fõtáblában akkor szúrjuk be
-Ha benne van módosítsuk
A mûvelet végén ürítsük a staging-et
*/

--mapping táblát létrehozása, feltöltése
create table map_companies(
	company_id int identity(1,1) not null constraint PK_map_companies primary key (company_id),
	company_name nvarchar(100) not null
)

create table map_payment(
	payment_id int identity(1,1) not null constraint PK_map_payment primary key (payment_id),
	payment_name nvarchar(100) not null
)

--mapping adatfeltöltés
insert into map_companies(company_name)
select
	distinct company
from stag_taxi_trips

insert into map_payment(payment_name)
select
	distinct payment_type
from stag_taxi_trips


--a fõ tábla létrehozása
drop table if exists  main_taxi_trips
create table main_taxi_trips(
	trip_id nvarchar(40) not null constraint PK_main_taxi_trips primary key (trip_id),
	taxi_id nvarchar(128) not null,
	trip_start_timestamp datetime not null,
	trip_end_timestamp datetime not null,
	trip_seconds int null,
	trip_miles decimal(10,4) null,
	pickup_community_area int null,
	fare decimal(10,4) null,
	tips decimal(10,4) null,
	tolls decimal(10,4) null,
	extras decimal(10,4) null,
	trip_total decimal(10,4) null,
	payment_type int null,
	company int null,
	pickup_centroid_latitude nvarchar(100) null,
	pickup_centroid_longitude nvarchar(100) null,
	dropoff_community_area int null,
	dropoff_centroid_latitude nvarchar(100) null,
	dropoff_centroid_longitude nvarchar(100) null
)

--idegen kulcsok definiálása a mappingekhez
alter table main_taxi_trips
	add constraint FK_taxi_comm_area_main_taxi_trips_pickup foreign key (pickup_community_area) references taxi_comm_area(area_id)

alter table main_taxi_trips
	add constraint FK_taxi_comm_area_main_taxi_trips_dropoff foreign key (dropoff_community_area) references taxi_comm_area(area_id)

alter table main_taxi_trips
	add constraint FK_map_company_main_taxi_trips foreign key (company) references map_companies(company_id)

alter table main_taxi_trips
	add constraint FK_map_payment_main_taxi_trips foreign key (payment_type) references map_payment(payment_id)

--fõtábla feltöltése
--A payment_type és a company kód a mapping táblákból jöjjönek át a név alapján

merge into main_taxi_trips as trg
using (
	select 
		trip_id,
		taxi_id,
		trip_start_timestamp,
		trip_end_timestamp,
		trip_seconds,
		trip_miles,
		pickup_community_area,
		fare,
		tips,
		tolls,
		extras,
		trip_total,
		p.payment_id as payment_id,
		c.company_id as company_id,
		pickup_centroid_latitude,
		pickup_centroid_longitude,
		dropoff_community_area,
		dropoff_centroid_latitude,
		dropoff_centroid_longitude
	from stag_taxi_trips as s
	left join map_companies as c on c.company_name = s.company
	left join map_payment as p on p.payment_name = s.payment_type
) as src on src.trip_id = trg.trip_id
when matched then
update set
		trip_id = src.trip_id,
		taxi_id = src.taxi_id,
		trip_start_timestamp = src.trip_start_timestamp,
		trip_end_timestamp = src.trip_end_timestamp,
		trip_seconds = src.trip_seconds,
		trip_miles = src.trip_miles,
		pickup_community_area = src.pickup_community_area,
		fare = src.fare,
		tips = src.tips,
		tolls = src.tolls,
		extras = src.extras,
		trip_total = src.trip_total,
		payment_type = src.payment_id, 
		company = src.company_id,
		pickup_centroid_latitude = src.pickup_centroid_latitude,
		pickup_centroid_longitude = src.pickup_centroid_longitude,
		dropoff_community_area = src.dropoff_community_area,
		dropoff_centroid_latitude = src.dropoff_centroid_latitude,
		dropoff_centroid_longitude = src.dropoff_centroid_longitude
when not matched by target then
	insert([trip_id], [taxi_id], [trip_start_timestamp], [trip_end_timestamp], [trip_seconds], [trip_miles], [pickup_community_area], [fare], [tips], [tolls], [extras], [trip_total], [payment_type], [company], [pickup_centroid_latitude], [pickup_centroid_longitude], [dropoff_community_area], [dropoff_centroid_latitude], [dropoff_centroid_longitude])
	values(
		src.trip_id,
		src.taxi_id,
		src.trip_start_timestamp,
		src.trip_end_timestamp,
		src.trip_seconds,
		src.trip_miles,
		src.pickup_community_area,
		src.fare,
		src.tips,
		src.tolls,
		src.extras,
		src.trip_total,
		src.payment_id, 
		src.company_id,
		src.pickup_centroid_latitude,
		src.pickup_centroid_longitude,
		src.dropoff_community_area,
		src.dropoff_centroid_latitude,
		src.dropoff_centroid_longitude
	);

truncate table stag_taxi_trips

/*
Készítsük el az adatbázis firssítésére vonatkozó scriptet is. Ennek fell kell töltenie a frissítést az adatbázisba.

Ellenõrizze hogy van-e új cég és fizetési típus, ha van akkor frissítse a mapping táblákat is.
*/



bulk insert dbo.stag_taxi_trips
from 'D:\doc\learn\Database\Data Engineer\hobby-projects\taxi-trips-sql-dev\taxi_trips 2024-04-09.csv'
with (
	firstrow = 2,
	fieldterminator = ';',
	ROWTERMINATOR = '\n',
	datafiletype = 'widechar',
	batchsize = 10000
)

--cégek frissítése
merge into dbo.map_companies as trg
using(
	select
		distinct company
	from dbo.stag_taxi_trips
	) as src on src.company = trg.[company_name]
when not matched by target then
	insert(company_name)
	values(src.company);

--payment frissítése
merge into dbo.map_payment as trg
using(
	select
		distinct payment_type
	from dbo.stag_taxi_trips
	) as src on src.payment_type = trg.[payment_name]
when not matched by target then
	insert([payment_name])
	values(src.payment_type);

--main feltöltése
merge into main_taxi_trips as trg
using (
	select 
		trip_id,
		taxi_id,
		trip_start_timestamp,
		trip_end_timestamp,
		trip_seconds,
		trip_miles,
		pickup_community_area,
		fare,
		tips,
		tolls,
		extras,
		trip_total,
		p.payment_id as payment_id,
		c.company_id as company_id,
		pickup_centroid_latitude,
		pickup_centroid_longitude,
		dropoff_community_area,
		dropoff_centroid_latitude,
		dropoff_centroid_longitude
	from stag_taxi_trips as s
	left join map_companies as c on c.company_name = s.company
	left join map_payment as p on p.payment_name = s.payment_type
) as src on src.trip_id = trg.trip_id
when matched then
update set
		trip_id = src.trip_id,
		taxi_id = src.taxi_id,
		trip_start_timestamp = src.trip_start_timestamp,
		trip_end_timestamp = src.trip_end_timestamp,
		trip_seconds = src.trip_seconds,
		trip_miles = src.trip_miles,
		pickup_community_area = src.pickup_community_area,
		fare = src.fare,
		tips = src.tips,
		tolls = src.tolls,
		extras = src.extras,
		trip_total = src.trip_total,
		payment_type = src.payment_id, 
		company = src.company_id,
		pickup_centroid_latitude = src.pickup_centroid_latitude,
		pickup_centroid_longitude = src.pickup_centroid_longitude,
		dropoff_community_area = src.dropoff_community_area,
		dropoff_centroid_latitude = src.dropoff_centroid_latitude,
		dropoff_centroid_longitude = src.dropoff_centroid_longitude
when not matched by target then
	insert([trip_id], [taxi_id], [trip_start_timestamp], [trip_end_timestamp], [trip_seconds], [trip_miles], [pickup_community_area], [fare], [tips], [tolls], [extras], [trip_total], [payment_type], [company], [pickup_centroid_latitude], [pickup_centroid_longitude], [dropoff_community_area], [dropoff_centroid_latitude], [dropoff_centroid_longitude])
	values(
		src.trip_id,
		src.taxi_id,
		src.trip_start_timestamp,
		src.trip_end_timestamp,
		src.trip_seconds,
		src.trip_miles,
		src.pickup_community_area,
		src.fare,
		src.tips,
		src.tolls,
		src.extras,
		src.trip_total,
		src.payment_id, 
		src.company_id,
		src.pickup_centroid_latitude,
		src.pickup_centroid_longitude,
		src.dropoff_community_area,
		src.dropoff_centroid_latitude,
		src.dropoff_centroid_longitude
	);

truncate table stag_taxi_trips


SELECT [trip_id]
      ,[taxi_id]
      ,[trip_start_timestamp]
      ,[trip_end_timestamp]
      ,[trip_seconds]
      ,[trip_miles]
      ,cap.area_name as pickup_com_area
      ,[fare]
      ,[tips]
      ,[tolls]
      ,[extras]
      ,[trip_total]
      ,p.payment_name
      ,c.[company_name]
      ,[pickup_centroid_latitude]
      ,[pickup_centroid_longitude]
      ,cad.area_name as dropoff_com_area
      ,[dropoff_centroid_latitude]
      ,[dropoff_centroid_longitude]
  FROM [taxi_trips].[dbo].[main_taxi_trips] as tt
  left join map_companies as c on c.company_id = tt.company
  left join map_payment as p on p.payment_id = tt.payment_type
  left join taxi_comm_area as cad on cad.area_id = tt.dropoff_community_area
  left join taxi_comm_area as cap on cap.area_id = tt.pickup_community_area