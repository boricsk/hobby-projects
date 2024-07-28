use MyDb
go

drop table if exists #employees
create table #employees(
    id int,
    Name nvarchar(100),
    salary int
)



insert into #employees
VALUES
    (1,'Samanta',1420),
    (2,'Julia', 2006),
    (3,'Maria',2210),
    (4,'Meera',3000),
    (5,'Ashley',2578)
    
drop table if exists #simulate
create table #simulate(
    id int,
    Name nvarchar(100),
    salary int
)

insert into #simulate(id, Name, salary)
select
    id,
    Name,
    CAST(REPLACE(CAST(salary AS VARCHAR), '0', '') AS INT)
from #employees
where CAST(REPLACE(CAST(salary AS VARCHAR), '0', '') AS INT) <> salary


select
    --avg(salary),
    --CAST(REPLACE(CAST(salary AS VARCHAR), '0', '') AS INT),
    avg(salary) - (select AVG(salary) from #simulate)
from #employees
--group by salary

select AVG(salary) from #simulate

--megoldás az avg-t kasztolni kell decimalra, mert mindí egészként adja vissza a szerver.
select
    --avg(salary),
    --CAST(REPLACE(CAST(salary AS VARCHAR), '0', '') AS INT),
    ceiling(avg(cast(salary as decimal))) - avg(CAST(REPLACE(CAST(salary AS VARCHAR), '0', '') AS INT))
from #employees
--group by salary


select 
    concat(max(months * salary),'  ',count(max(months * salary)))
from employee