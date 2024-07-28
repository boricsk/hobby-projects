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
    [Doctor], [Actor], [Singer], [Professor]
from ( select string_agg([Name], ', ') as Name, Occupation from #occupations group by Occupation) as source
pivot(
    MAX([Name])
    for Occupation in ([Doctor], [Actor], [Singer], [Professor])
) as pivottable





