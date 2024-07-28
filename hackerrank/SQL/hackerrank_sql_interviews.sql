drop table if exists #contests
create table #contests(
	contest_id int,
	hacker_id int,
	name nvarchar(50)
)

insert into #contests 
	values(66406, 17973, 'Rose'),
		  (66556, 79153, 'Angela'),
		  (94828, 80275, 'Frank')

drop table if exists #colleges
create table #colleges (
	college_id int,
	contest_id int
)

insert into #colleges 
	values(11219, 66406),
		  (32473, 66556),
		  (56685, 94828)

drop table if exists #challenges 
create table #challenges (
	challenge_id int,
	college_id int
)

insert into #challenges 
	values(18765, 11219),
		  (47127, 11219),
		  (60292, 32473),
		  (72974, 56685)


drop table if exists #view_stats 
create table #view_stats (
	challenge_id int,
	total_views int,
	total_unique_views int
)

insert into #view_stats 
	values(47127, 26, 19),
		  (47127, 15, 14),
		  (18765, 43, 10),
		  (18765, 72, 13),
		  (75516, 35, 17),
		  (60292, 11, 10),
		  (72974, 41, 15),
		  (75516, 75, 11)


drop table if exists #submission_stats 
create table #submission_stats (
	challenge_id int,
	total_submissions int,
	total_accepted_submissions int
)

insert into #submission_stats 
	values(75516, 34, 12),
		  (47127, 27, 10),
		  (47127, 56, 18),
		  (75516, 74, 12),
		  (75516, 83, 8),
		  (72974, 68, 24),
		  (72974, 82, 14),
		  (47127, 28, 11)

select
    con.contest_id,
    con.hacker_id,
    con.name,
    sum(ss.total_submissions),
    sum( ss.total_accepted_submissions),
    sum(ws.total_views),
    sum(ws.total_unique_views)
from #contests as con
left join #colleges as c on c.contest_id = con.contest_id
left join #challenges as chal on chal.college_id = c.college_id
left join #view_stats as ws on ws.challenge_id = chal.challenge_id
left join #submission_stats as ss on ss.challenge_id = ws.challenge_id
group by    
    con.contest_id,
    con.hacker_id,
    con.name
having  
    sum(ss.total_submissions) is not null and
    sum( ss.total_accepted_submissions) is not null and
    sum(ws.total_views) is not null and
    sum(ws.total_unique_views) is not null
order by con.contest_id;

/*
66406 17973 Rose 111 39 156 56
66556 79153 Angela 0 0 11 10
94828 80275 Frank 150 38 41 15
*/


drop table if exists #contests
create table #contests(
    contest_id int,
    hacker_id int,
    name nvarchar(50)
)

insert into #contests 
    values(66406, 17973, 'Rose'),
          (66556, 79153, 'Angela'),
          (94828, 80275, 'Frank')

drop table if exists #colleges
create table #colleges (
    college_id int,
    contest_id int
)

insert into #colleges 
    values(11219, 66406),
          (32473, 66556),
          (56685, 94828)

drop table if exists #challenges 
create table #challenges (
    challenge_id int,
    college_id int
)

insert into #challenges 
    values(18765, 11219),
          (47127, 11219),
          (60292, 32473),
          (72974, 56685)


drop table if exists #view_stats 
create table #view_stats (
    challenge_id int,
    total_views int,
    total_unique_views int
)

insert into #view_stats 
    values(47127, 26, 19),
          (47127, 15, 14),
          (18765, 43, 10),
          (18765, 72, 13),
          (75516, 35, 17),
          (60292, 11, 10),
          (72974, 41, 15),
          (75516, 75, 11)


drop table if exists #submission_stats 
create table #submission_stats (
    challenge_id int,
    total_submissions int,
    total_accepted_submissions int
)

insert into #submission_stats 
    values(75516, 34, 12),
          (47127, 27, 10),
          (47127, 56, 18),
          (75516, 74, 12),
          (75516, 83, 8),
          (72974, 68, 24),
          (72974, 82, 14),
          (47127, 28, 11)

select
    con.contest_id,
    con.hacker_id,
    con.name,
    sum(coalesce(ss.total_submissions, 0)),
    sum(coalesce(ss.total_accepted_submissions, 0)),
    sum(coalesce(ws.total_views, 0)),
    sum(coalesce(ws.total_unique_views, 0))
from #contests as con
left join #colleges as c on c.contest_id = con.contest_id
left join #challenges as chal on chal.college_id = c.college_id
left join #view_stats as ws on ws.challenge_id = chal.challenge_id
left join #submission_stats as ss on ss.challenge_id = chal.challenge_id
group by    
    con.contest_id,
    con.hacker_id,
    con.name
order by con.contest_id;
/*
66406 17973 Rose 111 39 156 56
66556 79153 Angela 0 0 11 10
94828 80275 Frank 150 38 41 15
*/