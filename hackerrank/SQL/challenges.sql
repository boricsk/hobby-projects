use MyDb
go

/*
Julia megkérte tanítványait, hogy készítsenek néhány kódolási kihívást. Írjon lekérdezést 
a hacker_id, név és az egyes tanulók által létrehozott kihívások számának kinyomtatásához. 
Rendezd az eredményeket a kihívások teljes száma szerint csökkenõ sorrendben. 
Ha egynél több tanuló hozott létre ugyanannyi kihívást, akkor rendezze az eredményt 
hacker_id szerint. Ha egynél több tanuló készített ugyanannyi kihívást, és a szám 
kevesebb, mint a létrehozott kihívások maximális száma, akkor ezeket a tanulókat zárja ki az eredménybõl.

*/

drop table if exists #hackers
create table #hackers(
	hacker_id int,
	name nvarchar(50)
)

insert into #hackers 
	values(5077, 'Rose'),
		  (21283, 'Angela'),
		  (62743, 'Frank'),
		  (88255, 'Patric'),
		  (96196, 'Lisa')

drop table if exists #challenges 
create table #challenges (
	challenge_id int,
	hacker_id int
)

insert into #challenges 
	values(61654, 5077),
		  (58302, 21283),
		  (40587, 88255),
		  (29477, 5077),
		  (1220, 21283),
		  (69514, 21283),
		  (45561, 62743),
		  (58077, 62743),
		  (18483, 88255),
		  (76766, 21283),
		  (52382, 5077),
		  (74467, 21283),
		  (33625, 96196),
		  (26053, 88255),
		  (42665, 62743),
		  (12859, 62743),
		  (70094, 21283),
		  (34599, 88255),
		  (54680, 88255),
		  (61881, 5077)

declare @max_challs int
drop table if exists #chall_count
select c.hacker_id, h.name, count(*) as challcount
into #chall_count
from #hackers as h
left join #challenges as c on h.hacker_id = c.hacker_id
group by c.hacker_id, h.name

select @max_challs = max(challcount) from #chall_count

drop table if exists #result
select *
into #result
from (select * from #chall_count 
except
select * from #chall_count where challcount in (select challcount as rep from #chall_count group by challcount having count(challcount) > 1) and challcount < @max_challs) as except_result
select * from #result order by challcount desc



/*
21283 Angela 6
88255 Patrick 5
96196 Lisa 1
*/


