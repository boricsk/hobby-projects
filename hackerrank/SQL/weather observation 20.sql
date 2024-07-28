use MyDB
go

/*
SELECT DISTINCT PERCENTILE_CONT(0.5) 
  WITHIN GROUP (ORDER BY list_price) OVER() AS "Median"
FROM sales.order_items

A függvény kiszámít egy adott percentilist egy adott oszlophoz egy csoporton belül. 
Az érv azt jelzi, hogy meg akarjuk találni az 50. percentilist, amely a medián. 
A záradék biztosítja, hogy a listaárak növekvõ sorrendbe legyenek rendezve a 
medián kiszámítása elõtt. A kulcsszó biztosítja, hogy csak egy eredményt kapjunk 
a teljes mediánra, még akkor is, ha több sor van ugyanazzal a medián értékkel. 
A függvény particionálás nélkül használható, így a a a teljes eredményhalmazra 
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