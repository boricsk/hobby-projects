use MyDb
go

/*
Harry Potter és barátai Ollivandernél vannak Ronnal, végre lecserélik Charlie régi törött pálcáját.

Hermione úgy dönt, hogy a legjobb módszert választja, ha meghatározza az egyes nagy teljesítményû és korú,
nem gonosz pálcák megvásárlásához szükséges aranygalleonok minimális számát. 
Írjon lekérdezést a Ront érdeklõ pálcák azonosítójának, korának, coins_needed és 
teljesítményének kinyomtatásához, csökkenõ teljesítmény szerint rendezve. 
Ha egynél több pálca ugyanolyan erõvel rendelkezik, rendezze az eredményt csökkenõ életkor szerint.

Beviteli formátum

A következõ táblázatok az Ollivander leltárában lévõ pálcákra vonatkozó adatokat tartalmazzák:

Pálcák: 
Az id a pálca azonosítója, 
a kód a pálca kódja, 
a coins_needed a pálca megvásárlásához szükséges aranygalleonok teljes száma, 
a teljesítmény pedig a pálca minõségét jelöli (minél nagyobb a teljesítmény, annál jobb a pálca).
 */

 drop table if exists #wands
 create table #wands(
	id int,
	code int,
	coins_needed int,
	power int,

 )

 /*
 Wands_Property: 
 A kód a pálca kódja, 
 az életkor a pálca kora, 
 az is_evil pedig azt jelzi, hogy a pálca jó-e a sötét mûvészetek számára. Ha az is_evil értéke 0, az azt jelenti, hogy a pálca nem gonosz. 
 A kód és az életkor közötti leképezés egy-egy, ami azt jelenti, hogy ha van két (code1, age1) és (code2, age2) akkor 
 code1 nem egyenlõ code2 és age1 nem egyenlõ age2
 */

 drop table if exists #wands_property
 create table #wands_property(
	code int,
	age int,
	is_evil int
 )

 insert into #wands
 values
	(1,4,3688,8),
	(2,3,9365,3),
	(3,3,7187,10),
	(4,3,734,8),
	(5,1,6020,2),
	(6,2,6773,7),
	(7,3,9873,9),
	(8,3,7721,7),
	(9,1,1647,10),
	(10,4,504,5),
	(11,2,7587,5),
	(12,5,9897,10),
	(13,3,4651,8),
	(14,2,5408,1),
	(15,2,6018,7),
	(16,4,7710,5),
	(17,2,8798,7),
	(18,2,3312,3),
	(19,4,7651,6),
	(20,5,5689,3)

insert into #wands_property
values
	(1,45,0),
	(2,40,0),
	(3,4,1),
	(4,20,0),
	(5,17,0)

select w.id, wp.age, w.coins_needed, w.power from #wands as w
left join #wands_property as wp on wp.code = w.code
where wp.is_evil = 0
order by 4 desc , 2 desc

--több egyforma power és age esetén a legolcsóbb
select 
	--*
	MIN(coins_needed) 
from #wands as w1
inner join #wands_property as wp1 on wp1.code = w1.code where w1.power = 7 and wp1.age = 40

--ennek mintájára kell egy subquery ami szûri a coins needed-et.

select w.id, wp.age, w.coins_needed, w.power from #wands as w
left join #wands_property as wp on wp.code = w.code
where coins_needed = (
	select min(w1.coins_needed) from #wands as w1
	inner join #wands_property as wp1 on wp1.code = w1.code where w1.power = w.power and wp1.is_evil = 0 and wp1.age = wp.age
)
order by w.power desc, wp.age desc
