/*
Három táblát kapsz: students, friends és packages. 
A tanulók két oszlopot tartalmaznak: ID és név. 
A Friends két oszlopot tartalmaz: ID és Friend_ID (az EGYETLEN legjobb barát azonosítója). 
A packages két oszlopot tartalmaznak: ID és fizetés (a felajánlott fizetés havi ezer dollárban).
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
Írjon lekérdezést azoknak a diákoknak a nevéhez, akiknek a legjobb barátai magasabb fizetést kaptak, 
mint õk. A neveket a legjobb barátoknak felajánlott fizetési összeg szerint kell rendezni. 
Garantált, hogy két diák nem kapott egyforma fizetési ajánlatot.
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