# A bemenet: PostgreSQL COPY parancs formátumú adatok
copy_data = """
1	Alabama	AL	south
2	Alaska	AK	north
3	Arizona	AZ	west
4	Arkansas	AR	south
5	California	CA	west
6	Colorado	CO	west
7	Connecticut	CT	east
8	Delaware	DE	east
9	District of Columbia	DC	east
10	Florida	FL	south
11	Georgia	GA	south
12	Hawaii	HI	west
13	Idaho	ID	midwest
14	Illinois	IL	midwest
15	Indiana	IN	midwest
16	Iowa	IO	midwest
17	Kansas	KS	midwest
18	Kentucky	KY	south
19	Louisiana	LA	south
20	Maine	ME	north
21	Maryland	MD	east
22	Massachusetts	MA	north
23	Michigan	MI	north
24	Minnesota	MN	north
25	Mississippi	MS	south
26	Missouri	MO	south
27	Montana	MT	west
28	Nebraska	NE	midwest
29	Nevada	NV	west
30	New Hampshire	NH	east
31	New Jersey	NJ	east
32	New Mexico	NM	west
33	New York	NY	east
34	North Carolina	NC	east
35	North Dakota	ND	midwest
36	Ohio	OH	midwest
37	Oklahoma	OK	midwest
38	Oregon	OR	west
39	Pennsylvania	PA	east
40	Rhode Island	RI	east
41	South Carolina	SC	east
42	South Dakota	SD	midwest
43	Tennessee	TN	midwest
44	Texas	TX	west
45	Utah	UT	west
46	Vermont	VT	east
47	Virginia	VA	east
48	Washington	WA	west
49	West Virginia	WV	south
50	Wisconsin	WI	midwest
51	Wyoming	WY	west

"""

# A mezőnevek, amik az adatbázis táblában vannak
fields = "usstates (stateid, statename, stateabbr, stateregion)"


# Spliteljük a bemeneti adatokat sorokra
rows = copy_data.strip().splitlines()

# Kiindulás a SQL INSERT parancs
sql_insert = "INSERT INTO " + fields + " VALUES\n"

# Az egyes sorok feldolgozása
values_list = []
for row in rows:
    # Spliteljük a sorokat tabulátor alapján
    columns = row.split('\t')
    # Cseréljük a \N karaktert NULL-ra
    columns = [col if col != '\\N' else 'NULL' for col in columns]
    # Escape aposztrófok és építsük fel a VALUES kifejezést
    values = "('" + "', '".join(col.replace("'", "''") for col in columns) + "')"
    # Adjunk hozzá egy új sort a values_list-hez
    values_list.append(values)

# Csatoljuk össze a SQL kifejezéseket vesszővel
sql_insert += ",\n".join(values_list) + ";"

# Kiírjuk a végső SQL INSERT parancsot
with open('output.txt', 'w', encoding = 'utf-8') as outfile:
    print(sql_insert, file = outfile)
