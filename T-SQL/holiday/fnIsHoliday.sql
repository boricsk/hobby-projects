/*
Húsvét vasárnapja minden évben a tavaszi napéjegyenlőséget követő holdtölte utáni első vasárnap, így dátuma március 22. és április 25. között változhat. 
Ennek meghatározására alkalmas a következő egyszerűsített algoritmus. Jelölje T az évszámot (1901<=T<=2099). Kiszámítjuk a következő osztási maradékokat:

    A = T / 19 maradéka
    B = T / 4 maradéka
    C = T / 7 maradéka
    D = (19A+24) / 30 maradéka
    E = (2B+4C+6D+5) / 7 maradéka.

Ezekből a húsvét-vasárnap dátuma H=22+D+E, ami márciusi dátum, ha H<=31, különben áprilisban H-31. 

Azonban létezik két kivétel: 
ha E=6 és D=29, akkor H=50, illetve 
ha E=6 és D=28 és A>10, akkor H=49. 

Pünkösd minden évben húsvét után hét héttel következik.

*/
create or alter function fn_IsHoliday(@date date, @weekend_check bit)
returns bit
as
begin
	declare
		@day_of_week smallint = datepart(weekday, @date),
		@month smallint = datepart(month, @date),
		@day smallint = datepart(day, @date),
		@first_of_march date = datefromparts(year(@date),3,1),
		@ret bit = 0,
		@t smallint = datepart(year, @date),
		@a smallint,
		@b smallint,
		@c smallint,
		@d smallint,
		@e smallint,
		@h smallint
		
	--húsvét, pünkösd

	set @a = @t % 19
	set @b = @t % 4
	set @c = @t % 7
	set @d = ((19 * @a) + 24) % 30
	set @e = (2 * @b + 4 * @c + 6 * @d + 5) % 7

	set @h = case
		when (@e = 6 and @d = 29) then 50
		when (@e = 6 and @d = 28 and @a > 10) then 49
		else 22 + @d + @e
	end

	declare @easter_monday date = DATEADD(day, @h, @first_of_march)
	declare @pentecost date = dateadd(day, 49, @easter_monday)

	if (@date = @easter_monday or @date = @pentecost) set @ret = 1 else set @ret = 0

	--állandó ünnepek, a hét első napja a hétfő
	if @@datefirst = 1
	begin
		if @weekend_check = 1
		begin
			if(@day_of_week in (6, 7)) or (
					(@month = 1 and @day = 1) or 
					(@month = 3 and @day = 15) or
					(@month = 3 and @day = 22) or --End year inventory
					(@month = 5 and @day = 1) or
					(@month = 8 and @day = 20) or
					(@month = 10 and @day = 23) or
					(@month = 11 and @day = 01) or
					(@month = 12 and @day = 25) or
					(@month = 12 and @day = 26)
					) 
			set @ret = 1 else set @ret = 0
		end else
		begin
			if((@month = 1 and @day = 1) or 
				(@month = 3 and @day = 15) or
				(@month = 3 and @day = 22) or --End year inventory
				(@month = 5 and @day = 1) or
				(@month = 8 and @day = 20) or
				(@month = 10 and @day = 23) or
				(@month = 11 and @day = 01) or
				(@month = 12 and @day = 25) or
				(@month = 12 and @day = 26)
				) 
			set @ret = 1 else set @ret = 0
		end
	end

	--állandó ünnepek a hét elsőnapja a vasárnap.
	if @@datefirst = 7
	begin
		if @weekend_check = 1
		begin
			if(@day_of_week in (1, 7)) or (
					(@month = 1 and @day = 1) or 
					(@month = 3 and @day = 15) or
					(@month = 3 and @day = 22) or --End year inventory
					(@month = 5 and @day = 1) or
					(@month = 8 and @day = 20) or
					(@month = 10 and @day = 23) or
					(@month = 11 and @day = 01) or
					(@month = 12 and @day = 25) or
					(@month = 12 and @day = 26)
					) 
			set @ret = 1 else set @ret = 0
		end else
		begin
			if((@month = 1 and @day = 1) or 
				(@month = 3 and @day = 15) or
				(@month = 3 and @day = 22) or --End year inventory
				(@month = 5 and @day = 1) or
				(@month = 8 and @day = 20) or
				(@month = 10 and @day = 23) or
				(@month = 11 and @day = 01) or
				(@month = 12 and @day = 25) or
				(@month = 12 and @day = 26)
					) 
			set @ret = 1 else set @ret = 0		
		end
	end
	return @ret
end
go
