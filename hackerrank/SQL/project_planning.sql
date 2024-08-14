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
Kapsz egy Projects nev� t�bl�t, amely h�rom oszlopot tartalmaz: Task_ID, Start_Date �s End_Date. 
Garant�ltan a End_Date �s a Start_Date k�z�tti k�l�nbs�g 1 nappal egyenl� a t�bl�zat minden sor�ban. 
Ha a feladatok End_Date �rt�ke egym�st k�vetik, akkor ugyanannak a projektnek a r�szei. Samanthat �rdekli, 
hogy megtudja a k�l�nb�z� befejezett projektek teljes sz�m�t.

�rjon lek�rdez�st a projektek kezd�si �s befejez�si d�tum�nak ki�r�s�hoz, a projekt befejez�s�hez 
sz�ks�ges napok sz�ma szerint, n�vekv� sorrendben.

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