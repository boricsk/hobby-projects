use MyDB
go

/*
You are given a table, BST, containing two columns: N and P, where N represents the value of a node in 
Binary Tree, and P is the parent of N.
*/

drop table if exists #bst
create table #bst (
	p int,
	n int
)
/*
Write a query to find the node type of Binary Tree ordered by the value of the node. Output one of the following for each node:

Root: If node is root node. (Nincs bemenõ node, csak kimenõ)
Leaf: If node is leaf node. (Csak bemenõ node van)
Inner: If node is neither root nor leaf node. (Be és kimenõ node is van)
*/

insert into #bst values
	(1, 2	),
	(3, 2	),
	(5, 6	),
	(7, 6	),
	(2, 4	),
	(6, 4	),
	(4, 15	),
	(8, 9	),
	(10, 9	),
	(12, 13	),
	(14, 13	),
	(9 ,11	),
	(13, 11	),
	(11, 15	),
	(15, NULL)
	
	
	/*
	(1,2),
	(3,2),
	(6,8),
	(9,8),
	(2,5),
	(8,5),
	(5,null)*/
/*
Sample Output

1 Leaf
2 Inner
3 Leaf
5 Root
6 Leaf
8 Inner
9 Leaf
*/

select
 case 
	when n is null then concat(p, ' Root')
	when p not in (select n from #bst where n is not null) then CONCAT(p, ' Leaf')
	when p in (select n from #bst where n is not null) then CONCAT(p, ' Inner') 
  end
from #bst
order by p

select * from #bst
/*
(1, 2	)
(3, 2	)
(5, 6	)
(7, 6	)
(2, 4	)
(6, 4	)
(4, 15	)
(8, 9	)
(10, 9	)
(12, 13	)
(14, 13	)
(9 ,11	)
(13, 11	)
(11, 15	)
(15, NULL)*/

select
 n,
 case
	when p is null then 'Root'
	when n in (select p from #bst) then 'Inner' else 'Leaf'
  end
from #bst
order by n

