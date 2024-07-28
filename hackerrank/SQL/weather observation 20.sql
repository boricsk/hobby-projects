use MyDB
go

/*
SELECT DISTINCT PERCENTILE_CONT(0.5) 
  WITHIN GROUP (ORDER BY list_price) OVER() AS "Median"
FROM sales.order_items

A f�ggv�ny kisz�m�t egy adott percentilist egy adott oszlophoz egy csoporton bel�l. 
Az �rv azt jelzi, hogy meg akarjuk tal�lni az 50. percentilist, amely a medi�n. 
A z�rad�k biztos�tja, hogy a lista�rak n�vekv� sorrendbe legyenek rendezve a 
medi�n kisz�m�t�sa el�tt. A kulcssz� biztos�tja, hogy csak egy eredm�nyt kapjunk 
a teljes medi�nra, m�g akkor is, ha t�bb sor van ugyanazzal a medi�n �rt�kkel. 
A f�ggv�ny particion�l�s n�lk�l haszn�lhat�, �gy a a a teljes eredm�nyhalmazra 
vonatkozik.PERCENTILE_CONT0.5ORDER BY list_priceDISTINCTOVER()PERCENTILE_CONT
*/

WITH Median AS ( 
	SELECT DISTINCT PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY LAT_N) OVER () AS Median_Value FROM Station 
) 
SELECT 
	CAST(Median_Value AS Decimal(10,4)) 
FROM Median
go

with median as (
	select distinct PERCENTILE_CONT(0.5) within group (Order by lat_n) over() as "MedianValue"
	from station
) 
select
	cast(MedianValue as decimal(10,4))
from median