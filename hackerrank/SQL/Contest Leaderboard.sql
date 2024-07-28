use MyDb
go

/*
Annyira nagyszerû munkát végzett, hogy segített Juliának a legutóbbi kódverseny kihívásában, 
hogy azt szeretné, ha ezen is dolgoznál!
A hacker összpontszáma az összes kihívásra adott maximális pontszámának összege. 
Írjon lekérdezést a hackerek hacker_id-jének, nevének és összpontszámának kinyomtatásához 
csökkenõ pontszám szerint. Ha egynél több hacker érte el ugyanazt az összpontszámot, 
rendezze az eredményt növekvõ hacker_id szerint. Az összes hacker kizárása a teljes 
pontszámmal az eredményébõl.
*/

drop table if exists #Hackers
create table #Hackers(
	hacker_id int,
	name nvarchar(100)
)

insert into #Hackers
values
	(4071, 'Rose'),
	(4806, 'Angela'),
	(26071, 'Frank'),
	(49438, 'Patrick'),
	(74842, 'Lisa'),
	(80305, 'Kimberly'),
	(84072, 'Bonnie'),
	(87868, 'Michael'),
	(92118, 'Todd'),
	(85895, 'Joe')

drop table if exists #Submissions
create table #Submissions (
	sublission_id int,
	hacker_id int,
	challenge_id int,
	score int
)

insert into #Submissions
values
	(67194,74842,63132,76),
	(64479,74842,19797,98),
	(40742,26071,49593,20),
	(17513,4806,49593,32),
	(69846,80305,19797,19),
	(41002,26071,89343,36),
	(52826,49438,49593,9),
	(31093,26071,19797,2),
	(81614,84072,49593,100),
	(44829,26071,89343,17),
	(75174,80305,49593,48),
	(14115,4806,49593,76),
	(6943,4071,19797,95),
	(12855,4806,25917,13),
	(73343,80305,49593,42),
	(84264,84072,63132,0),
	(9951,4071,49593,43),
	(45104,49438,25917,34),
	(53795,74842,19797,5),
	(26363,26071,19797,29),
	(10063,4071,49593,96)

select s. hacker_id, h.name, s.score, s.challenge_id from #Submissions as s
left join #Hackers as h on h.hacker_id = s.hacker_id
where s.hacker_id = 4071