drop table if exists #projects
create table #projects(
	task_id int,
	start_date date,
	end_date date
)

insert into #projects
values
	(1, '2015-10-01','2015-10-02'),
	(2, '2015-10-02','2015-10-03'),
	(3, '2015-10-03','2015-10-04'),
	(4, '2015-10-13','2015-10-14'),
	(5, '2015-10-14','2015-10-15'),
	(6, '2015-10-28','2015-10-29'),
	(7, '2015-10-30','2015-10-31')

select * from #projects
/*
Kapsz egy Projects nevû táblát, amely három oszlopot tartalmaz: Task_ID, Start_Date és End_Date. 
Garantáltan a End_Date és a Start_Date közötti különbség 1 nappal egyenlõ a táblázat minden sorában. 
Ha a feladatok End_Date értéke egymást követik, akkor ugyanannak a projektnek a részei. Samanthat érdekli, 
hogy megtudja a különbözõ befejezett projektek teljes számát.

Írjon lekérdezést a projektek kezdési és befejezési dátumának kiírásához, a projekt befejezéséhez 
szükséges napok száma szerint, növekvõ sorrendben.

A minta kimenet:

2015-10-28 2015-10-29
2015-10-30 2015-10-31
2015-10-13 2015-10-15
2015-10-01 2015-10-04

*/
go

with cte as (
	select 
		start_date,
		row_number() over (order by start_date) as start_date_rank
	from #projects where start_date not in (select end_date from #projects)
),
cte2 as (
	select
		end_date,
		row_number() over (order by end_date) as end_date_rank
	from #projects where end_date not in (select start_date from #projects)

)
select c1.start_date, c2.end_date
from cte as c1
left join cte2 as c2 on c1.start_date_rank = c2.end_date_rank
order by DATEDIFF(day, c1.start_date, c2.end_date), start_date
go
--vagy
with cte_1 as (
select
	start_date
from #projects
except
select
	lag(end_date) over (order by end_date)
from #projects
),
cte_2 as (
select
	end_date
from #projects
except
select
	lag(start_date) over (order by start_date)
from #projects
)
select 
	c1.start_date, 
	c2.end_date
from (select *, row_number() over (order by start_date) as start_date_rank from cte_1) as c1
left join (select *, row_number() over(order by end_date) as end_date_rank from cte_2) as c2 on c1.start_date_rank = c2.end_date_rank
order by DATEDIFF(day, c1.start_date, c2.end_date), c1.start_date