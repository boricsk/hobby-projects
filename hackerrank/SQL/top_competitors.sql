use MyDB
go

drop table if exists #Hackers
create table #Hackers(
	hacker_id int,
	name nvarchar(100)
)

drop table if exists #Difficulty
create table #Difficulty (
	difficulty_level int,
	score int
)

drop table if exists #Challenges
create table #Challenges (
	challenge_id int,
	hacker_id int,
	difficulty_level int
)

drop table if exists #Submissions
create table #Submissions (
	sublission_id int,
	hacker_id int,
	challenge_id int,
	score int
)

insert into #Hackers
values
	(5580, 'Rose'),
	(8439, 'Angela'),
	(27205, 'Frank'),
	(52243, 'Patrick'),
	(52348, 'Lisa'),
	(57645, 'Kimberly'),
	(77726, 'Bonnie'),
	(83082, 'Michael'),
	(86870, 'Todd'),
	(90411, 'Joe')

insert into #Difficulty
values
	(1,20),
	(2,30),
	(3,40),
	(4,60),
	(5,80),
	(6,100),
	(7,120)

insert into #Challenges
values
	(4810,77726,4),
	(21089,27205,1),
	(36566,5580,7),	
	(66730,52243,6),
	(71055,52243,2)

insert into #Submissions
values
	(68628,77726,36566,30),
	(65300,77726,21089,10),
	(40326,52243,36566,77),
	(8941,27205,4810,4),
	(83554,77726,66730,30),
	(43353,52243,66730,0),
	(55385,52348,71055,20),
	(39784,27205,71055,23),
	(94613,86870,71055,30),
	(45788,52348,36566,0),
	(93085,86870,36566,30),
	(7344,8439,66730,92),
	(2721,8439,4810,36),
	(523,5580,71055,4),
	(94105,52348,66730,0),
	(55877,57645,66730,80),
	(38355,27205,66730,35),
	(3924,8439,36566,80),
	(39397,90411,66730,100),
	(84162,83082,4810,40),
	(97431,90411,71055,30)

/*
Julia éppen most végzett egy kódolóverseny lebonyolításával, és szüksége van a segítségedre 
a ranglista összeállításához! Írjon lekérdezést a megfelelõ hacker_id és azon hackerek nevének 
kinyomtatásához, akik egynél több kihívásnál teljes pontszámot értek el. Rendezze a kimenetet 
csökkenõ sorrendbe azon kihívások száma szerint, amelyekben a hacker teljes pontszámot szerzett. 
Ha egynél több hacker kapott teljes pontszámot ugyanannyi kihívásban, akkor rendezze õket növekvõ 
hacker_id szerint.

Minta kimenet

90411 Joe

Magyarázat

A 86870-es hacker 30 pontot kapott a 71055-ös kihívásért, 2-es nehézségi szinttel, így a 86870-es teljes pontszámot kapott ennél a kihívásnál.
A 90411-es hacker 30 pontot kapott a 71055-ös kihívásért, 2-es nehézségi fokozattal, tehát 90411-es teljes pontszámot ért el ennél a kihívásnál.
A Hacker 90411 100 pontot kapott a 66730-as kihívásért, 6-os nehézségi fokozattal, így 90411 teljes pontszámot kapott ennél a kihívásnál.
Csak a 90411 hackernek sikerült egynél több kihívásért teljes pontszámot szereznie, ezért szóközzel elválasztott értékként nyomtatjuk ki 
a hacker_id-jüket és a nevét.
*/

select concat(s.hacker_id ,' ', h.name)
from #Submissions as s
left join #Hackers as h on h.hacker_id = s.hacker_id
left join #Challenges as c on c.challenge_id = s.challenge_id
left join #Difficulty as d on d.difficulty_level = c.difficulty_level
where s.score = d.score
group by s.hacker_id, h.name
having COUNT(*) > 1
order by COUNT(s.hacker_id) desc, 1 asc