use MyDB
go
/*
Az Amber konglomer�tum v�llalata most v�s�rolt fel n�h�ny �j c�get. Mindegyik v�llalat ezt a hierarchi�t k�veti:
Az al�bbi t�bl�zats�m�k alapj�n �rjon le egy lek�rdez�st a c�gk�d, az alap�t� nev�nek, a vezet� menedzserek teljes sz�m�nak, 
a fels�vezet�k teljes sz�m�nak, a vezet�k teljes sz�m�nak �s az alkalmazottak teljes sz�m�nak kinyomtat�s�hoz. 
Rendezze a kimenetet n�vekv� c�gk�d szerint.

Jegyzet:

A t�bl�k ism�tl�d� rekordokat tartalmazhatnak.
A company_code karakterl�nc, ez�rt a rendez�s nem lehet numerikus. P�ld�ul, ha a v�llalati_k�dok C_1, C_2 �s C_10, 
akkor a n�vekv� c�gk�dok C_1, C_10 �s C_2 lesznek.

Beviteli form�tum
Az al�bbi t�bl�zatok a c�gadatokat tartalmazz�k:
C�g: A company_code a c�g k�dja, az alap�t� pedig a c�g alap�t�ja.
Lead_Manager: A lead_manager_code a vezet� menedzser k�dja, a company_code pedig a m�k�d� v�llalat k�dja.
Senior_Manager: A senior_manager_code a fels�vezet� k�dja, a lead_manager_code a vezet� menedzser�nek k�dja, a v�llalati_k�d pedig a m�k�d� c�g k�dja.
Menedzser: A menedzser_k�d a vezet� k�dja, a fels�vezet�i_k�d a fels�vezet�j�nek, a vezet�_vezet� k�dja a vezet� menedzser�nek k�dja, a v�llalati_k�d pedig a m�k�d� c�g k�dja.
Alkalmazott: A munkav�llal�i_k�d a munkav�llal� k�dja, a vezet�i_k�d a vezet�j�nek, a fels�vezet�i_k�d a fels�vezet�j�nek a k�dja, a vezet�_vezet� k�dja a vezet� vezet�j�nek k�dja, a v�llalati_k�d pedig a dolgoz� c�g k�dja. .

*/

drop table if exists #Company
create table #Company (
	company_code nvarchar(10),
	founder nvarchar(10)
	)
insert into #Company values
	('C1','Monika'),
	('C2', 'Samantha')


drop table if exists #Lead_Manager
create table #Lead_Manager (
	lead_manager_code nvarchar(10),
	company_code nvarchar(10)
	)
insert into #Lead_Manager values
	('LM1','C1'),
	('LM2', 'C2')


drop table if exists #Senior_Manager
create table #Senior_Manager (
	senior_manager_code nvarchar(10),
	lead_manager_code nvarchar(10),
	company_code nvarchar(10)
	)
insert into #Senior_Manager values
	('SM1','LM1','C1'),
	('SM2','LM1','C1'),
	('SM3','LM2','C2')


drop table if exists #Manager
create table #Manager (
	manager_code nvarchar(10),
	senior_manager_code nvarchar(10),
	lead_manager_code nvarchar(10),
	company_code nvarchar(10)
	)
insert into #Manager values
	('M1','SM1','LM1','C1'),
	('M2','SM3','LM2','C2'),
	('M3','SM3','LM2','C2')


drop table if exists #Employee
create table #Employee (
	employee_code nvarchar(10),
	manager_code nvarchar(10),
	senior_manager_code nvarchar(10),
	lead_manager_code nvarchar(10),
	company_code nvarchar(10)
	)
insert into #Employee values
	('E1','M1','SM1','LM1','C1'),
	('E2','M1','SM1','LM1','C1'),
	('E3','M2','SM3','LM2','C2'),
	('E4','M3','SM3','LM2','C2')


/*
Minta kimenet

C1 M�nika 1 2 1 2
C2 Samantha 1 1 2 2

Magyar�zat

A C1 v�llalatn�l az egyetlen vezet� menedzser az LM1. Az LM1 alatt k�t fels�vezet� van, az SM1 �s az SM2. 
Az SM1 fels�vezet� alatt egy vezet� van, az M1. K�t alkalmazott, az E1 �s az E2 az M1 �gyvezet�je alatt �ll.
A C2 v�llalatn�l az egyetlen vezet� menedzser az LM2. Az LM2 alatt van egy fels�vezet�, az SM3. 
K�t vezet�, az M2 �s az M3 van az SM3 fels�vezet� alatt. Van egy alkalmazott, az E3, az M2 vezet�, 
�s egy m�sik alkalmazott, az E4, az M3.
*/
select 
	c.company_code,
	c.founder, 
	count(distinct lm.lead_manager_code),
	count(distinct sm.senior_manager_code),
	count(distinct mg.manager_code),
	count(distinct e.employee_code)
from #Company as c
left join #Lead_Manager as lm on lm.company_code = c.company_code
left join #Senior_Manager as sm on sm.company_code = lm.company_code
left join #Manager as mg on mg.company_code = sm.company_code
left join #Employee as e on e.company_code = sm.company_code
group by c.company_code, c.founder, lm.lead_manager_code