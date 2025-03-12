//https://www.codewars.com/kata/51fda2d95d6efda45e00004e/train/csharp
/*
 Írjon egy User nevű osztályt, amely kiszámítja azt az összeget, amelyet a felhasználó a Codewars által 
használthoz hasonló rangsorolási rendszerben halad előre.

Üzletszabályzat:
A felhasználó -8-as rangról indul, és egészen 8-ig haladhat.
Nincs 0 (nulla) rang. A -1 után következő rangsor az 1.
A felhasználók elvégzik a tevékenységeket. Ezeknek a tevékenységeknek is vannak rangjai.
Minden alkalommal, amikor a felhasználó végrehajt egy rangsorolt ​​tevékenységet, a felhasználók rangsorolásának 
előrehaladása a tevékenység rangsorolása alapján frissül
A befejezett tevékenység által elért előrehaladás a felhasználó aktuális rangjához viszonyítva a tevékenység 
rangjához képest
A felhasználó rangsorolása nulláról indul, és minden alkalommal, amikor az előrehaladás eléri a 100-at, a felhasználó 
rangja a következő szintre emelkedik
Bármilyen hátralévő haladás, amelyet az előző fokozatban szerzett, a következő rangban elért előrehaladása során 
érvényesül (nem dobunk el). Kivételt képez, ha már nincs más fokozat, ahová tovább lehet lépni (a 8. fokozat elérése 
után nincs továbblépés).
A felhasználó nem léphet tovább a 8-as rangnál.
A rangértékek egyetlen elfogadható tartománya a -8,-7,-6,-5,-4,-3,-2,-1,1,2,3,4,5,6,7,8. Minden más érték hibát jelez.
A haladás pontozása a következőképpen történik:

A felhasználó tevékenységével azonos rangú tevékenység elvégzése 3 pontot ér
Egy olyan tevékenység elvégzése, amelynek rangsorolása egy rangsorolással alacsonyabb, mint a felhasználóé, 1 pontot ér
A rendszer figyelmen kívül hagyja azokat a tevékenységeket, amelyek legalább 2 szinttel alacsonyabbak, mint a 
felhasználó rangsorolása
Az aktuális felhasználó rangjánál magasabb rangú tevékenység elvégzése felgyorsítja a rangsorolást. Minél nagyobb a 
rangsorok közötti különbség, annál nagyobb lesz az előrehaladás. A képlet 10 * d * d, ahol d egyenlő a tevékenység 
és a felhasználó rangsorolási különbségével.
Logikai példák:
Ha egy -8-as rangú felhasználó végrehajt egy -7-es rangú tevékenységet, akkor 10-es előrelépést kap
Ha egy -8-as rangú felhasználó végrehajt egy -6-os rangú tevékenységet, akkor 40 előrelépést kap
Ha egy -8-as rangú felhasználó végrehajt egy -5-ös rangú tevékenységet, akkor 90-es előrelépést kap
Ha egy -8-as rangú felhasználó végrehajt egy -4-es rangú tevékenységet, akkor 160-as előrelépést kap, ami azt eredményezi, 
hogy a felhasználó -7-es rangra emelkedik, és 60-at ér el a következő rangra.
Ha egy -1-es besorolású felhasználó egy 1-es rangú tevékenységet végez, 10-et kap (ne feledje, a nulla helyezést figyelmen 
kívül hagyja)
Példák a kód használatára:
User user = new User();
user.rank; // => -8
user.progress; // => 0
user.incProgress(-7);
user.progress; // => 10
user.incProgress(-5); // 90 haladást ad hozzá
user.progress; // => 0 // a haladás most nulla
user.rank; // => -7 // a rang -7-re frissítve
Megjegyzés: A C#-ban néhány metódus ArgumentException-t dobhat.

Megjegyzés: A Codewars már nem használja ezt az algoritmust saját rangsoroló rendszeréhez. Tisztán matematikai megoldást használ, amely konzisztens eredményeket ad, függetlenül attól, hogy a rangsorolt ​​tevékenységek milyen sorrendben fejeződnek be.
 */

namespace _027_CodewarsRanking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User u = new User();
            Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            u.incProgress(-8);
            Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            u.incProgress(-1);
            Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            //u.incProgress(-1);
            //Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            //u.incProgress(-2);
            //Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            //u.incProgress(-1);
            //Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            //u.incProgress(1);
            //Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            //u.incProgress(2);
            //Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            //u.incProgress(3);
            //Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            //u.incProgress(4);
            //Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
            //u.incProgress(5);
            //Console.WriteLine($"Progress : {u.progress} / rank : {u.rank}");
        }
    }
}
