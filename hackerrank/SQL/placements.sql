/*
H�rom t�bl�t kapsz: students, friends �s packages. 
A tanul�k k�t oszlopot tartalmaznak: ID �s n�v. 
A Friends k�t oszlopot tartalmaz: ID �s Friend_ID (az EGYETLEN legjobb bar�t azonos�t�ja). 
A packages k�t oszlopot tartalmaznak: ID �s fizet�s (a felaj�nlott fizet�s havi ezer doll�rban).
*/

drop table if exists #students
create table #students (
	id smallint,
	name nvarchar(100)
)

drop table if exists #friends
create table #friends (
	id smallint,
	friend_id smallint

)

drop table if exists #packages
create table #packages (
	id smallint,
	salary decimal(6,2)
	
)

/*
�rjon lek�rdez�st azoknak a di�koknak a nev�hez, akiknek a legjobb bar�tai magasabb fizet�st kaptak, 
mint �k. A neveket a legjobb bar�toknak felaj�nlott fizet�si �sszeg szerint kell rendezni. 
Garant�lt, hogy k�t di�k nem kapott egyforma fizet�si aj�nlatot.
*/

insert into #students values
	(1, 'Ashley'),
	(2, 'Samantha'),
	(3, 'Julia'),
	(4, 'Scarlet')

insert into #friends values
	(1, 2),
	(2, 3),
	(3, 4),
	(4, 1)

insert into #packages values
	(1, 15.20),
	(2, 10.06),
	(3, 11.55),
	(4, 12.12)

select s1.name from #students as s1
left join #friends as f1 on f1.id = s1.id
left join #packages as p on p.id = f1.id
left join #students as s2 on s2.id = f1.friend_id
left join #packages as p2 on p2.id = s2.id
where p.salary < p2.salary
order by p2.salary

select * from #packages