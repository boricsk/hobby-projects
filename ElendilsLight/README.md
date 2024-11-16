## Elendil fénye

<img src=elendils-light.jpg>

Szarumán elfogott száz tündét és bezárta őket Vasudvardba. Minden tünde egy olyan zárkába került, amelyből lehetetlen kommunikálni a többiekkel. A trollok naponta egyet vagy többet közülük kivisznek friss levegőt szívni. Minden ilyen esemény alatt kizárólag egy tünde tartózkodik kint. A trollok tökéletesen véletlenszerűen választják ki, hogy éppen kit vigyenek levegőzni. Az udvaron található egy kis üveg, amelyben Elendil fénye ragyog. Ha egy tünde megérinti az üveget, a fény kialszik, vagy éppen újra elkezd ragyogni, attól függően, hogy éppen milyen állapotban volt ezt megelőzően. A tündék kizárólag ilyen úton képesek egymással kommunikálni. Szarumán – mivel éppen a saját születésnapján fogta el a tündéket – tesz egy engedményt: egy nappal korábban tájékoztatja őket az üveg működéséről, valamint a levegőzések rendszeréről. Ezen felül azt a javaslatot teszi, hogy ha valamelyik tünde egy levegőzés során százszázalékos biztonsággal ki tudja jelenteni, hogy már mindenki járt a szabadban a trollokkal, akkor szabadon enged mindenkit. Ha azonban helytelen az állítás, a rabság az idők végezetéig fog tartani.

Ez a repo egy szimulációs programot tartalmaz a fenti problémára amely kiszámolja azt, hogy hány forduló után lehet 100%-os bizonyossággal megmondani, hogy már mindenki volt kint.
<br>
<br>

## Miért jó a tesztelés

Segített rávilágítani egy logikai hibára, ugyanis készítettem egy olyan tesztet, ami az egész működést teszteli. A kód első verziójában a Count változó inkrementációját úgy oldottam meg, hogy egy esemény fut le a amikor a lámpa állapota megváltozik. A kód látszólag helyesen működött, viszont a teszt során a lenti hibára derült fény:

<img src=elendils-light-fail-test.jpg>

Ez a teszt metódus azt nézi megy, hogy az isTurn tömbben mennyi true érték van. Ez a tömb reprezentálja, hogy melyik fogoly kapcsolta a lámpát. Itt kiderült, hogy a választott módszer a Count növelésére nem volt jó, mivel itt csak arra vagyok kíváncsi, hogy a főnök hányszor kapcsolta fel a lámpát, nem pedig arra, hogy összesen mennyi volt a kapcsolások száma, ugyanis a Count értékét akkor is növeltem, amikor lekapcsolták a lámpát. Ennek az lett az eredménye, hogy a Count idő előtt érte el a megfelelő értéket, másképp fogalmazva az isTurn tömbben maradt false érték, ami azt jelenti, hogy nem kapcsolt az illető. Mivel a megoldási logika az, hogy csak a főnöknek kinevezett Tünde tud felkapcsolni és a felkapcsolások számát kell számolnia, a többiek csak lekapcsolhatnak de azt is csak egyszer, így nem jelenthető ki bizonyosan, hogy mindenki volt kint. A kód javításában kiszedtem az érintett eseményt és egyszerűbben oldottam meg a Count növelését, így helyesen lefutott a teszt is :

<img src=elendils-light-pass-test.jpg>
