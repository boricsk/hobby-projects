use MyDB
go

drop table if exists #students
create table #students (
	id int,
	name nvarchar(100),
	marks int
)

insert into #students 
values
	(1, 'Julia', 88),
	(2, 'Samantha', 68),
	(3, 'Maria', 100),
	(4, 'Scarlet', 78),
	(5, 'Ashley', 63),
	(6, 'Jane', 81)


drop table if exists #grades
create table #grades (
	grade int,
	min_mark int,
	max_mark int
)

insert into #grades 
values
	(1,0,9),
	(2,10,19),
	(3,20,29),
	(4,30,39),
	(5,40,49),
	(6,50,59),
	(7,60,69),
	(8,70,79),
	(9,80,89),
	(10,90,100)

select 
	case when marks <=69 then null else name end as name,
	(select g.grade from #grades as g where g.min_mark <= marks and g.max_mark >= marks) as grade,
	marks	
from #students
order by (select g.grade from #grades as g where g.min_mark <= marks and g.max_mark >= marks) desc, name, marks
