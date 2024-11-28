## Borics Krisztián
### Snippet Store

Biztosan voltatok már olyan helyzetben egy nagyobb project esetén, hogy olyan problémát kellett megoldani
amit már megoldottatok. Ilyenkor megy a keresgetés, hogy a több ezernyi kódsorban valyon hol van az amit keresünk.
Ez az app erre próbál megoldást nyújtani. Segítségével egy helyi telepítésű vagy cloud-os (Atlas) MongoDb
adatbáziba menthetjük el a kódrészleteket, majd gyors kereséseket végezhetünk az adatbázisban.

### Telepítés előtti előkészületek
Abban az esetben, ha az appot helyi telepítésű adatbázison szeretnénk használni szükség van a MongoDb telepítésére, ami szolgáltatáskén fog futni a rendszerünkön. A telepítő innen tölthető le, valamit itt olvashatóak instrukciók a telepítéssel kapcsolatban.[ MongoDb Community Server Download ](https://www.mongodb.com/try/download/community)
Felhős használat esetén a szolgáltató oldalára történő regisztrációval lehet használni az appot. Én a MongoDb Atlast javaslom, ez 512MB adatbázisméretig ingyenes. [ MongoDb Atlas ](https://www.mongodb.com/products/platform/atlas-database)

### Telepítés
A telepítés elvégezhető a telepítővel vagy a kód letöltés utánni fordításával is. Mindkét esetben .NET szükséges a futtatáshoz, amit a Microsoft oldaláról lehet letölteni. [ .NET Download ](https://dotnet.microsoft.com/en-us/download) A telepítés után az asztalon lévő parancsikonnal indítható a program.

### Főoldal

<img src=./pic/scr-main.jpg >
<br><br>
A toolbar gombjaival a kövekető funkciókat lehet elérni.

- Új kódrészlet hozzáadás
- Beállítás
- Kódrészlet törlése
- Kódrészlet módosításának mentése
- Módosítás mentésének elvetése
- Fanézet kibontása
- Fanézet összecsukása
- Kódrészlet másolása
- Másolat készítésre a felhős adatbázisból a helyi adatbázisba

Bal oldalon az adatbázisban lévő kódrészletek vannak csoportosítva nyelvenként. Jobbra fönt a kódrészlet szerkesztőablaka látható, jobbra lent pedig kis statisztika arról, hogy az adott nyelvek milyen arányban fordulnak elő az adatbázisban, illetve itt van egy top 5 nézettségi statisztika is.

### Beállítás
<img src=./pic/scr-setup-1.jpg ><br><br>

Mielőtt a használatot megkezdenénk fell kell vinni azokat a programozási nyelveket, amelyeket használni szeretnénk. Ezt az Add language részben lehet megtenni. LEhetőségünk van kulcsszavak rögzítésére is, amiket a kódrészlet felvitelénél lehet majd használni valamint hatékonyabbá tenni velük a keresést. A Search in .. részben azt lehet beállítani, hogy a gyorskeresés melyik adatbáziskollekciót vegye figyelembe.<br><br>
Syntax fül<br>
<img src=./pic/scr-setup-2.jpg ><br><br>
Az appban van egy alap szintaktika kiemelő. Az Add reswrved word részben lehet megadni azokat a szavakat amit a color gombbal kiválasztott szíben szeretnénk látni a főablak szerkesztőjében. az Add block separator esetében a helyzet ugyanez. Jobb oldalon kell megadni az adatbázisok kapcsolódásához használatos constring-eket. Ha a Use local database be van pipálva akkor a helyi adatbázist fogja használni a program. Ha ezt változtatjuk újra kell indítani az appot. A save config gombot ne felejtsük el legyomni, ez fogja a beállításokat menteni.


### Kódrészlet hozzáadása
<img src=./pic/scr-add-snip.jpg ><br><br>

1. Válasszuk ki a listából a programozási nyelvet. Itt azok a nyelvek láthatóak, amelyeket a beállításban rögzítettünk.
2. Kulcsszavak hozzáadása a >> gomb segítségével lehetséges. A - gombbal ki lehet venni a kijelölt szót a listából. A jobb oldali lista fogja azokat a kulcsszavakat mutatni, amelyek mentésre kerülnek az adatbázisba. A zölddel jelölt rész egy keresőmező, itt a kulcsszavak között tudunk keresni. Ha valamelyik kulcsszót szeretnénk végleg eltávolítani azt a beállításokban tudjuk megtenni a Remove gombbal.
4. Adjunk egy nevet a kódrészletnek. 
5. Ha szeretnénk hosszabb megjegyzést írni itt lehet megtenni
6. Másoljuk be a kódot, majd az Add to database gombbal menteni lehet.

Két azonos nevő kódrészlet nem megengedett. Ha van már ilyen akkor azt piros háttérrel jelzi.<br>
<img src=./pic/scr-exist-snip.jpg ><br><br>


### Keresés
<img src=./pic/scr-find.jpg ><br><br>

A fanézet feletti szövegmezőbe lehet beírni a keresendő kifejezést. Figyelni kell arra, hogy kis és nagybetű érzékeny a keresés.

### Törlés
<img src=./pic/scr-del-snip.jpg ><br><br>

Amikor egy kódrészt kiválasztunk akkor a törlés gomb aktív lesz és a megnyomásával lehet törölni a kiválasztott kódrészletet.