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

using System.Data;

static int lnko(int x, int y) //GCD
{
    while (y != 0)
    {
        int temp = y;
        y = x % y;
        x = temp;
    }
    return x;
}

static int lkkt(int x, int y) //LCM
{
    return (x * y) / lnko(x, y);
}

static int get_lkkt(List<int> arr)
{
    int lkkt_value = arr[0];

    for (int i = 1; i < arr.Count; i++)
    {
        lkkt_value = lkkt(lkkt_value, arr[i]);
    }
    return lkkt_value;
}

static int get_lnko(List<int> arr)
{
    int lnko_value = arr[0];

    for (int i = 1; i < arr.Count; i++)
    {
        lnko_value = lnko(lnko_value, arr[i]);
    }
    return lnko_value;
}

static int getTotalX(List<int> a, List<int> b)
{
    int result = 0;
    int lkkt_a = get_lkkt(a); //lcm
    int lnko_b = get_lnko(b); //gcd
    List<int> temp = new List<int>();

    for (var i = lkkt_a; i < lnko_b + 1; i += lkkt_a)
    {
        if (lnko_b % i == 0) { temp.Add(i); }
    }
    return temp.Count;
}

List<int> a = new List<int>();
List<int> b = new List<int>();

a.Add(2);
a.Add(6);
b.Add(24);
b.Add(36);

Console.WriteLine(getTotalX(a, b));
