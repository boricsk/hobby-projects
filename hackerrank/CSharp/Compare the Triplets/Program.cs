/*
 Alice és Bob egy-egy problémát csinált a HackerRank számára. 
A bíráló értékeli a két kihívást, és egy 1-től 100-ig terjedő skálán pontokat ad három kategóriában: 

probléma egyértelműsége, eredetiség és nehézség.

Alice kihívásának értékelése a hármas a = (a[0], a[1], a[2]), 
Bob kihívásának pedig a hármas b = (b[0], b[1], b [2]).

A feladat az, hogy megtaláljuk összehasonlítási pontjaikat úgy, hogy a[0]-t b[0]-val, a[1]-t b[1]-el, és a[2]-t b[2]-vel hasonlítjuk össze.

 Ha a[i] > b[i], akkor Alice 1 pontot kap.
 Ha a[i] < b[i], akkor Bob 1 pontot kap.
 Ha a[i] = b[i], akkor egyik személy sem kap pontot.

Összehasonlítási pontok az összes pont, amit egy személy szerzett.

Adott a és b, határozza meg a megfelelő összehasonlítási pontokat.

Példa

a = [1, 2, 3]
b = [3, 2, 1]

 A *0* elemekért Bob pontot kap, mert a[0] .
 Az a[1] és b[1] egyenlő elemekért nem jár pont.
 Végül a 2. elemekre a[2] > b[2], így Alice pontot kap.

A visszatérési tömb [1, 1], ahol Alice pontszáma az első, Bobé pedig a második.

Funkció leírás

Töltse ki az összehasonlító Triplet függvényt az alábbi szerkesztőben.

Az összehasonlítástripletek a következő paraméterekkel rendelkeznek:

 int a[3]: Alice kihívás értékelése
 int b[3]: Bob kihívás értékelése
 */



static List<int> compareTriplets(List<int> a, List<int> b)
{
    int bob = 0;
    int alice = 0;
    List<int> result = new List<int>();

    for (int i = 0; i <= 2; i++)
    {
        if (a[i] > b[i]) { alice++; }
        else if (a[i] < b[i]) { bob++; }
    }

    result.Add(alice);
    result.Add(bob);

    return result;
}


List<int> a = new List<int>();
List<int> b = new List<int>();
List<int> c = new List<int>();

a.Add(1);
a.Add(2);
a.Add(3);

b.Add(3);
b.Add(2);
b.Add(1);

compareTriplets(a, b);