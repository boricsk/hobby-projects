/*
 Két egész szám tömbje lesz. Határozza meg az összes olyan egész számot, amely teljesíti a következő két feltételt:

 Az első tömb elemei mind tényezői a figyelembe vett egész számnak
 A figyelembe vett egész szám a második tömb összes elemének tényezője

Ezeket a számokat a két tömb közötti számoknak nevezzük. Határozza meg, hány ilyen szám létezik!

Példa
a = [2,6]
b = [24,36]
6 és 12 a két szám a tömbök között.
Első számhoz
6%2 = 0
6%6 = 0
24%6 = 0
36%6 = 0

Másodikhoz
12%2 = 0
12%6 = 0
24%12 = 0
36%12 = 0

Eredmény 2

*/

static List<int> FindCommonDivisors(int x, int y)
{
    List<int> divisors = new List<int>();
    int gcd = GreatestCommonDivisor(x, y);
    Console.WriteLine($" GCD {gcd}");
    for (int i = 1; i <= gcd; i++)
    {
        if (gcd % i == 0)
        {
            divisors.Add(i);
            Console.WriteLine(i);
        }
    }

    return divisors;
}

static int GreatestCommonDivisor(int x, int y)
{
    while (y != 0)
    {
        int temp = y;
        y = x % y;
        x = temp;
    }
    return x;
}

static int getTotalX(List<int> a, List<int> b)
{
    int result = 0;

    return result;
}

List<int> a = new List<int>();
List<int> b = new List<int>();

a.Add(2);
a.Add(6);
b.Add(24);
b.Add(36);

getTotalX(a, b);
