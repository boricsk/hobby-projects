/*
Ön egy cirkuszi előadást koreografál különféle állatokkal. 
Egy felvonásra két kengurut kapsz egy számegyenesen, 
amelyek készen állnak arra, hogy a pozitív irányba 
(azaz a pozitív végtelen felé) ugorjanak.

Az első kenguru az x1 helyről indul, és ugrásonként v1 méteres sebességgel mozog.
A második kenguru az x2 helyről indul, és ugrásonként v2 méteres sebességgel mozog.

Ki kell találnia a módját, hogy mindkét kengurut ugyanarra a helyre kerüljön. 
Ha lehetséges, írjon IGEN-t, ellenkező esetben NEM-et.

Példa
x1 = 2
v1 = 1

x2 = 1
v2 = 2

Egy ugrás után mindketten x = 3 , (x1 + v1 = 2 + 1 = 3, x2 + v2 = 1 + 2 = 3) pontban állnak, tehát a válasz IGEN.


 * Complete the 'kangaroo' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts following parameters:
 *  1. INTEGER x1
 *  2. INTEGER v1
 *  3. INTEGER x2
 *  4. INTEGER v2
 */

static string kangaroo(int x1, int v1, int x2, int v2)
{
    string result = "";
    int total1 = x1 + v1;
    int total2 = x2 + v2;

    for (int i = 1; i <= 10000; i++)
    {
        if (total1 == total2) { result = "YES"; break; } else { result = "NO"; }
        total1 += v1;
        total2 += v2;
    }
    return result;
}

static string kangaroo2(int x1, int v1, int x2, int v2)
{
    string result = "";
    int total1 = x1 + v1;
    int total2 = x2 + v2;
    int v_dif = Math.Abs(v1 - v2);
    int x_dif = Math.Abs(x1 - x2);

    if (total1 == total2) { result = "YES"; }
    else if (v2 > v1 && x2 > x1) { result = "NO"; }
    else if (v1 > v2 && x1 > x2) { result = "NO"; }
    else if (v_dif == 0) { result = "NO"; }
    else if (x_dif % v_dif == 0) { result = "YES"; } else {  result = "NO";  }

    return result;
}

Console.WriteLine(kangaroo2(43, 2, 70, 2));