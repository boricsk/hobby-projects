use MyDb
go

/*
Harry Potter �s bar�tai Ollivandern�l vannak Ronnal, v�gre lecser�lik Charlie r�gi t�r�tt p�lc�j�t.

Hermione �gy d�nt, hogy a legjobb m�dszert v�lasztja, ha meghat�rozza az egyes nagy teljes�tm�ny� �s kor�,
nem gonosz p�lc�k megv�s�rl�s�hoz sz�ks�ges aranygalleonok minim�lis sz�m�t. 
�rjon lek�rdez�st a Ront �rdekl� p�lc�k azonos�t�j�nak, kor�nak, coins_needed �s 
teljes�tm�ny�nek kinyomtat�s�hoz, cs�kken� teljes�tm�ny szerint rendezve. 
Ha egyn�l t�bb p�lca ugyanolyan er�vel rendelkezik, rendezze az eredm�nyt cs�kken� �letkor szerint.

Beviteli form�tum

A k�vetkez� t�bl�zatok az Ollivander lelt�r�ban l�v� p�lc�kra vonatkoz� adatokat tartalmazz�k:

P�lc�k: 
Az id a p�lca azonos�t�ja, 
a k�d a p�lca k�dja, 
a coins_needed a p�lca megv�s�rl�s�hoz sz�ks�ges aranygalleonok teljes sz�ma, 
a teljes�tm�ny pedig a p�lca min�s�g�t jel�li (min�l nagyobb a teljes�tm�ny, ann�l jobb a p�lca).
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
 A k�d a p�lca k�dja, 
 az �letkor a p�lca kora, 
 az is_evil pedig azt jelzi, hogy a p�lca j�-e a s�t�t m�v�szetek sz�m�ra. Ha az is_evil �rt�ke 0, az azt jelenti, hogy a p�lca nem gonosz. 
 A k�d �s az �letkor k�z�tti lek�pez�s egy-egy, ami azt jelenti, hogy ha van k�t (code1, age1) �s (code2, age2) akkor 
 code1 nem egyenl� code2 �s age1 nem egyenl� age2
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

--t�bb egyforma power �s age eset�n a legolcs�bb
select 
	--*
	MIN(coins_needed) 
from #wands as w1
inner join #wands_property as wp1 on wp1.code = w1.code where w1.power = 7 and wp1.age = 40

--ennek mint�j�ra kell egy subquery ami sz�ri a coins needed-et.

select w.id, wp.age, w.coins_needed, w.power from #wands as w
left join #wands_property as wp on wp.code = w.code
where coins_needed = (
	select min(w1.coins_needed) from #wands as w1
	inner join #wands_property as wp1 on wp1.code = w1.code where w1.power = w.power and wp1.is_evil = 0 and wp1.age = wp.age
)
order by w.power desc, wp.age desc
