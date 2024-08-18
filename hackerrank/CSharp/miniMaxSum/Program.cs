/*
 Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers. 
Then print the respective minimum and maximum values as a single line of two space-separated long integers. 

Example:
arr = [1,3,5,7,9]

Minimum sum : 1+3+5+7 = 16
Maximum sum : 3+5+7+9 = 24

Output format : 
16 24
 */

using System.Globalization;

static void miniMaxSum(List<int> arr)
{
    long totalsum = arr.Sum(i => (long)i);
    long maxsum = totalsum - arr.Min();
    long minsum = totalsum - arr.Max();
    
    Console.WriteLine($"{minsum} {maxsum}");
   
}

List<int> numbers = new List<int>(); 
numbers.Add(156873294);
numbers.Add(719583602);
numbers.Add(581240736);
numbers.Add(605827319);
numbers.Add(895647130);

miniMaxSum(numbers);

/*
 Az `i` a kódban egy lambda kifejezés része, amely az `arr.Sum(i => (long)i)` kifejezésben szerepel. 
Ez a kifejezés egy iteráló változót definiál a lambda kifejezésben, amely a lista minden elemét jelöli egyenként.

Mi az a lambda kifejezés?

A lambda kifejezés egy rövid szintaxis arra, hogy névtelen függvényeket hozzunk létre C#-ban. 
Ezeket gyakran használják olyan esetekben, amikor egyszerűen csak egy műveletet szeretnél 
végrehajtani minden elemre egy gyűjteményben, például a `Sum` metódussal.

Hogyan működik ez a konkrét esetben?

- **`i => (long)i`**: A lambda kifejezés azt mondja, hogy az `arr.Sum` minden egyes elemét (`i`) alakítsa át `long` típusúvá, mielőtt összeadná őket.
- Az `i` a lista aktuális elemét jelenti az iterálás során.
- A `(long)i` kifejezés azt jelenti, hogy a lista aktuális `int` típusú elemét `long` típusra alakítjuk, mielőtt az összegzés történne.

Ez a megközelítés biztosítja, hogy az összegzés `long` típusban történjen, elkerülve az `int` túlcsordulást.

Tehát az `i` itt egyszerűen a listában szereplő egyes elemeket jelöli a `Sum` függvény végrehajtása során. A lambda kifejezés formája hasonló a következőhöz:

arr.Sum(item => (long)item);

Itt az `item` az `i` helyettesítésére szolgál, és ugyanolyan jelentéssel bír. Az `i` tehát egy helyi változó, amely a `List<int>` egy elemére mutat az iteráció során.
 */