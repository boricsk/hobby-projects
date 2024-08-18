use MyDb
go
/*
Julia vetetta a SQL 15 nap alatt tanulási versenyt. 
A verseny kezdési dátuma 2016. március 01., a záró dátuma 2016. március 15. volt.

Írjon egy lekérdezést, hogy kinyomtassa azon egyedi hackerek számát, akiknek legalább napi 1 feladatbeküldésük volt
(a verseny elsõ napjától kezdõdõen), és meg kell keresni a hacker_id azonosítóját és annak a hackernek a nevét, 
aki naponta a legtöbb feladatot küldte be. Ha egynél több ilyen hacker rendelkezik maximális számú beküldéssel, 
nyomtassa ki a legalacsonyabb hacker_id értéket. A lekérdezésnek ki kell nyomtatnia ezt az információt a 
verseny minden napjára vonatkozóan, dátum szerint rendezve.
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
