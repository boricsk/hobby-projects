drop table if exists #occupations
create table #occupations (
    Name nvarchar(50),
    Occupation NVARCHAR(50)
)

insert into #occupations
values
    ('Samantha', 'Doctor'),
    ('Julia', 'Actor'),
    ('Maria', 'Actor'),
    ('Meera', 'Singer'),
    ('Ashely', 'Professor'),
    ('Ketty', 'Professor'),
    ('Christeen', 'Professor'),
    ('Jane', 'Actor'),
    ('Jenny', 'Doctor'),
    ('Priya', 'Singer') 

select 
    max(case when Occupation = 'Doctor' then Name end),
    min(case when Occupation = 'Professor' then Name end),
    max(case when Occupation = 'Actor' then Name end),
    min(case when Occupation = 'Singer' then Name end),
    rn
from (
    select name, occupation, ROW_NUMBER() over (partition by Occupation Order by Name) as rn
    from #occupations
) as occuprow
group by rn

select name, occupation, ROW_NUMBER() over (partition by Occupation Order by Name) as rn
from #occupations