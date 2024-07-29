/*
Ebben a kihívásban ki kell számítania és ki kell nyomtatnia egy tömb elemeinek 
összegét, szem előtt tartva, hogy ezek közül néhány egész szám meglehetősen nagy lehet.

Funkció leírás

Töltse ki az aVeryBigSum függvényt az alábbi szerkesztőben. 
A tömb összes elemének összegét kell visszaadnia.

az aVeryBigSum a következő paraméterekkel rendelkezik:

 int ar[n]: egész számok tömbje .

Visszatérés

 long: a tömb összes elemének összege

Beviteli formátum

A bemenet első sora egy egész számból áll.
A következő sor tartalmazza

a tömbben található szóközzel elválasztott egész számok.

Kimeneti formátum

A tömb elemeinek egész összegét adja vissza.
 */


using System.Text.Json.Serialization;

static long aVeryBigSum(List<long> ar)
{
    Console.WriteLine(ar.Sum());
    return ar.Sum();
}

List<long> longs = new List<long>();

longs.Add(1000000001);
longs.Add(1000000002);
longs.Add(1000000003);
longs.Add(1000000004);
longs.Add(1000000005);

aVeryBigSum(longs);
