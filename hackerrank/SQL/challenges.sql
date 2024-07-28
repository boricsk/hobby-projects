use MyDb
go

/*
Julia megk�rte tan�tv�nyait, hogy k�sz�tsenek n�h�ny k�dol�si kih�v�st. �rjon lek�rdez�st 
a hacker_id, n�v �s az egyes tanul�k �ltal l�trehozott kih�v�sok sz�m�nak kinyomtat�s�hoz. 
Rendezd az eredm�nyeket a kih�v�sok teljes sz�ma szerint cs�kken� sorrendben. 
Ha egyn�l t�bb tanul� hozott l�tre ugyanannyi kih�v�st, akkor rendezze az eredm�nyt 
hacker_id szerint. Ha egyn�l t�bb tanul� k�sz�tett ugyanannyi kih�v�st, �s a sz�m 
kevesebb, mint a l�trehozott kih�v�sok maxim�lis sz�ma, akkor ezeket a tanul�kat z�rja ki az eredm�nyb�l.

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


