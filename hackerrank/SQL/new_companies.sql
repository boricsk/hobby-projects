use MyDB
go
/*
Az Amber konglomerátum vállalata most vásárolt fel néhány új céget. Mindegyik vállalat ezt a hierarchiát követi:
Az alábbi táblázatsémák alapján írjon le egy lekérdezést a cégkód, az alapító nevének, a vezetõ menedzserek teljes számának, 
a felsõvezetõk teljes számának, a vezetõk teljes számának és az alkalmazottak teljes számának kinyomtatásához. 
Rendezze a kimenetet növekvõ cégkód szerint.

Jegyzet:

A táblák ismétlõdõ rekordokat tartalmazhatnak.
A company_code karakterlánc, ezért a rendezés nem lehet numerikus. Például, ha a vállalati_kódok C_1, C_2 és C_10, 
akkor a növekvõ cégkódok C_1, C_10 és C_2 lesznek.

Beviteli formátum
Az alábbi táblázatok a cégadatokat tartalmazzák:
Cég: A company_code a cég kódja, az alapító pedig a cég alapítója.
Lead_Manager: A lead_manager_code a vezetõ menedzser kódja, a company_code pedig a mûködõ vállalat kódja.
Senior_Manager: A senior_manager_code a felsõvezetõ kódja, a lead_manager_code a vezetõ menedzserének kódja, a vállalati_kód pedig a mûködõ cég kódja.
Menedzser: A menedzser_kód a vezetõ kódja, a felsõvezetõi_kód a felsõvezetõjének, a vezetõ_vezetõ kódja a vezetõ menedzserének kódja, a vállalati_kód pedig a mûködõ cég kódja.
Alkalmazott: A munkavállalói_kód a munkavállaló kódja, a vezetõi_kód a vezetõjének, a felsõvezetõi_kód a felsõvezetõjének a kódja, a vezetõ_vezetõ kódja a vezetõ vezetõjének kódja, a vállalati_kód pedig a dolgozó cég kódja. .

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

C1 Mónika 1 2 1 2
C2 Samantha 1 1 2 2

Magyarázat

A C1 vállalatnál az egyetlen vezetõ menedzser az LM1. Az LM1 alatt két felsõvezetõ van, az SM1 és az SM2. 
Az SM1 felsõvezetõ alatt egy vezetõ van, az M1. Két alkalmazott, az E1 és az E2 az M1 ügyvezetõje alatt áll.
A C2 vállalatnál az egyetlen vezetõ menedzser az LM2. Az LM2 alatt van egy felsõvezetõ, az SM3. 
Két vezetõ, az M2 és az M3 van az SM3 felsõvezetõ alatt. Van egy alkalmazott, az E3, az M2 vezetõ, 
és egy másik alkalmazott, az E4, az M3.
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