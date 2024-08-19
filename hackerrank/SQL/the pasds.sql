use myDB
GO

drop table if exists #occupations
create table #occupations(
    Name nvarchar(100),
    Occupation nvarchar(100)
)

insert into #occupations
VALUES
    ('Samanta','Doctor'),
    ('Julia','Actor'),
    ('Maria','Actor'),
    ('Meera','Singer'),
    ('Ashley','Professor'),
    ('Ketty','Professor'),
    ('Christeen','Professor'),
    ('Jane','Actor'),
    ('Jenny','Doctor'),
    ('Priya','Singer')

select 
    concat(Name,'(',LEFT(Occupation,1),')')
from #occupations
order by Name

select 
    --Occupation,
    concat('There are a total of ', count(Occupation),' ' ,lower(Occupation),'s.')
from #occupations
GROUP by Occupation
ORDER by count(Occupation) asc, Occupation asc