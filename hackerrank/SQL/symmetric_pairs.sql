/*
Adott egy tábla functions.
*/

drop table if exists #functions
create table #functions (
	x int,
	y int
)

insert into #functions values
	(20,20),
	(20,20),	
	(20,21),	
	(23,22),	
	(22,23),	
	(21,20)

/*
Két pár esetén (x1,y1) és (x2,y2) szimmetrikus a pár, ha x1 = y2 és x2 = y1.
Írj lekérdezést amely kilistázza a szimmetrikus párokat x szerint növekvõbe rendezve
*/

select 
	
	f1.x, 
	f1.y
	
from #functions as f1
join #functions as f2 on f1.x = f2.y and f2.x = f1.y 
group by f1.x, f1.y 
having 
count(f1.x) > 1 or f1.x < f1.y