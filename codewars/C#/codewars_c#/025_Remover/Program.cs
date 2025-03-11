/*
A hihetetlenül unalmas dolgok múzeuma
A hihetetlenül unalmas dolgok múzeuma meg akar szabadulni néhány kiállítási tárgytól. 
Miriam, a belsőépítész kitalál egy tervet, hogy eltávolítja a legunalmasabb kiállítási 
tárgyakat. Értékeli őket, majd eltávolítja a legalacsonyabb értékelést kapót.

Azonban éppen akkor, amikor befejezte az összes kiállítási tárgy értékelését, elutazik 
egy fontos vásárra, ezért megkér téged, hogy írj egy programot, amely megmondja neki 
a kiállítási tárgyak értékelését, miután eltávolította a legalacsonyabbat. Elég tisztességes.

Feladat
Adott egy egész számokból álló tömb, távolítsd el a legkisebb értéket. 
Ne változtasd meg az eredeti tömböt/listát. Ha több azonos értékű elem van, 
akkor azt távolítsd el, amelyiknek a legkisebb az indexe. Ha üres tömböt/listát kapunk, 
adjunk vissza egy üres tömböt/listát.

Ne változtassa meg a megmaradt elemek sorrendjét.
* Input: [1,2,3,4,5], output = [2,3,4,5]
* Input: [5,3,2,1,4], output = [5,3,2,4]
* Input: [2,2,1,2,1], output = [2,2,2,1]

 */

namespace _025_Remover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RemoveSmallest([2, 2, 1, 2, 1]);
        }

        public static List<int> RemoveSmallest(List<int> numbers)
        {
            if (numbers.Count == 0) return numbers;
            numbers.Remove(numbers.Min());
            return numbers;

        }
    }
}
