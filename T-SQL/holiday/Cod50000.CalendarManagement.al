codeunit 50000 "Calendar Management"
{
    var
        holidays: Dictionary of [Integer, Integer];

    trigger OnRun()
    begin
        //fix ünnepek feltöltése
        holidays.Add(1, 1);
        holidays.Add(3, 15);
        holidays.Add(3, 22);
        holidays.Add(5, 1);
        holidays.Add(8, 20);
        holidays.Add(10, 23);
        holidays.Add(11, 1);
        holidays.Add(12, 25);
        holidays.Add(12, 26);
    end;

    //meghatározzuk, hogy a húsvét hétfő hány napra van március 1.-től.
    procedure getEasterMonday(year: Integer): Date
    var
        result, a, b, c, d, e, h : Integer;
    begin
        a := year mod 19;
        b := year mod 4;
        c := year mod 7;
        d := ((19 * a) + 24) mod 30;
        e := (2 * b + 4 * c + 6 * d + 5) mod 7

        if (e = 6) and (d = 29)
        then begin
            result := 50
        end
        else begin
            if (e = 6) and (d = 28) and (a > 10)
            then begin
                result := 49
            end
            else begin
                result := 22 + d + e
            end;
        end;
        exit(DMY2Date(1, 3, year) + result);
    end;
    //Pünkösd meghatározása
    procedure getPentecostDay(easterMonday: Date): Date
    begin
        exit(easterMonday + 49);
    end;

    procedure isHoliday(check_Date: Date): Boolean
    var
        month, day : Integer;
        holiday_month: Integer;
        holiday_day: Integer;
    begin
        month := Date2DMY(check_Date, 2);
        day := Date2DMY(check_Date, 1);
        if check_Date = getEasterMonday(Date2DMY(check_Date, 3)) then exit(true);
        if check_Date = getPentecostDay(getEasterMonday(Date2DMY(check_Date, 3))) then exit(true);
        if (Date2DWY(check_Date, 1) = 6) or (Date2DWY(check_Date, 1) = 7) then exit(true);

        foreach holiday_month in holidays.Keys() do begin
            if (month = holiday_month) and (day = holidays.Get(holiday_month)) then
                exit(true);
        end;
    end;
}
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
