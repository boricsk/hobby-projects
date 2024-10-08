/*
Egy lelkes túrázó aprólékos nyilvántartást vezet túráiról. Az utolsó, 
pontosan lépésben járó túra során minden lépésnél feljegyezték, hogy 
felfelé, U , vagy lefelé, D [steps] lépésről van szó. A túrák mindig 
a tengerszinten kezdődnek és érnek véget, és minden felfelé vagy 
lefelé lépés 1 egységnyi magasságváltozást jelent. A következő 
fogalmakat határozzuk meg:

-A hegy a tengerszint feletti egymást követő lépések sorozata, kezdve 
a tengerszintről való fellépéssel és a tengerszintre való lelépéssel végződve.

-A völgy egymást követő lépések sorozata a tengerszint alatt, kezdve 
a tengerszintről lefelé lépéssel és a tengerszintre való fellépéssel végződve.

-A túra során felfelé és lefelé haladó lépések sorrendjét figyelembe 
véve keresse meg és nyomtassa ki a bejárt völgyek számát.

Példa

steps = 8 path = [DDUUUUDD]

A túrázó először egy 2 egység mély völgybe lép be. Aztán kimásznak és 
fel egy 2 egység magas hegyre. Végül a túrázó visszatér a tengerszintre, 
és befejezi a túrát.

UDDDUDUU
-> 1

A túrázó 1 völgybe ment be és abból jött ki.

_/\      _
   \    /
    \/\/

*/
namespace Counting_Valleys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "UDDDUDUU";
            Console.WriteLine(countingValleys(8, path));
        }

        public static int countingValleys(int steps, string path)
        {
            
            int high = 0;
            int valleys = 0;

            foreach (int step in path)
            {
                if (step == 'U')
                {
                    high++;
                    if (high == 0) { valleys++; }
                    continue;
                } else { high--; }
            }

            return valleys;
        }
    }
}
