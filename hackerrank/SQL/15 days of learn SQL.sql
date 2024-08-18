use MyDb
go
/*
Julia vetetta a SQL 15 nap alatt tanul�si versenyt. 
A verseny kezd�si d�tuma 2016. m�rcius 01., a z�r� d�tuma 2016. m�rcius 15. volt.

�rjon egy lek�rdez�st, hogy kinyomtassa azon egyedi hackerek sz�m�t, akiknek legal�bb napi 1 feladatbek�ld�s�k volt
(a verseny els� napj�t�l kezd�d�en), �s meg kell keresni a hacker_id azonos�t�j�t �s annak a hackernek a nev�t, 
aki naponta a legt�bb feladatot k�ldte be. Ha egyn�l t�bb ilyen hacker rendelkezik maxim�lis sz�m� bek�ld�ssel, 
nyomtassa ki a legalacsonyabb hacker_id �rt�ket. A lek�rdez�snek ki kell nyomtatnia ezt az inform�ci�t a 
verseny minden napj�ra vonatkoz�an, d�tum szerint rendezve.
*/

drop table if exists #Hackers
create table #Hackers(
	hacker_id int,
	name nvarchar(100)
)

insert into #Hackers
values
	(15785, 'Rose'),
	(20703, 'Angela'),
	(36396, 'Frank'),
	(38289, 'Patrick'),
	(44065, 'Lisa'),
	(53473, 'Kimberly'),
	(62529, 'Bonnie'),
	(79722, 'Michael')


drop table if exists #Submissions
create table #Submissions (
	submission_date date,
	sublission_id int,
	hacker_id int,
	score int
)

insert into #Submissions
values
	('2016-03-01',8494,20703,0),
	('2016-03-01',22403,53473,15),
	('2016-03-01',23965,79722,60),
	('2016-03-01',30173,36396,70),

	('2016-03-02',34928,20703,0),
	('2016-03-02',38740,15758,60),
	('2016-03-02',42769,79722,25),
	('2016-03-02',44364,79722,60),

	('2016-03-03',45440,20703,0),
	('2016-03-03',49050,36396,70),
	('2016-03-03',50273,79722,5),

	('2016-03-04',50344,20703,0),
	('2016-03-04',51360,44065,90),
	('2016-03-04',54404,53473,65),
	('2016-03-04',61533,79722,45),

	('2016-03-05',72852,20703,0),
	('2016-03-05',74546,38289,0),
	('2016-03-05',76487,62529,0),
	('2016-03-05',82439,36396,10),
	('2016-03-05',90006,36396,40),
	('2016-03-06',90404,20703,0)

go

with data as(
    select 
        s.submission_date, 
        s.hacker_id, 
        h.name,
        count(*) submissions, 
        row_number() over(partition by  s.submission_date  order by count(*) desc, s.hacker_id) as day_rank,
        dense_rank() over(order by s.submission_date) as day_number,
        dense_rank() over(partition by s.hacker_id order by s.submission_date) as day_hacker
    from #Submissions s
    INNER JOIN #Hackers h ON s.hacker_id = h.hacker_id
    group by s.submission_date, s.hacker_id, h.name
)
select submission_date,
	sum(case when day_number = day_hacker then 1 else 0 end),
	min(case when day_rank = 1 then  hacker_id end),
	min(case when day_rank = 1 then  name end)
from data
group by submission_date
order by submission_date
