/*
Két gyerek, Lily és Ron szeretne megosztani egy csokit. 
Mindegyik négyzeten van egy egész szám.

Lily úgy dönt, hogy megosztja a kiválasztott sáv egy 
összefüggő szegmensét, így:

 -A szegmens hossza megegyezik Ron születési hónapjával, és
 -A négyzeteken lévő egész számok összege megegyezik a születési napjával.

Határozza meg, hányféleképpen tudja elosztani a csokoládét.

Példa

s = [2,2,1,3,2]
d = 4
m = 2

Lily olyan szegmenseket szeretne találni, amelyek összege Ron 
születési napja, d = 4, és amelyek hossza megegyezik a 
születési hónapjával, m = 2 . Ebben az esetben két szegmens 
felel meg a kritériumainak: [2,2] és [1,3].

Bemenet
-Az első sor egy egész számot tartalmaz n, a csokoládéban lévő négyzetek számát.
-A második sor n szóközzel elválasztott egész számot tartalmaz , s[i] a csokoládé négyzeteken lévő számokat, ahol 0 <= i < n.
-A harmadik sor két szóközzel elválasztott egész számot tartalmaz, d és m , Ron születési napját és születési hónapját.
*/
namespace subarray_division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>() { 2, 2, 1, 3, 2 };
            List<int> list2 = new List<int>() { 4 };
            List<int> list3 = new List<int>() { 2, 5, 1, 3, 4, 4, 3, 5, 1, 1, 2, 1, 4, 1, 3, 3, 4, 2, 1 };
            //Console.WriteLine(birthday(list1, 4, 2));
            Console.WriteLine(birthday(list3, 18, 7));

        }

        public static int birthday(List<int> s, int d, int m)
        {
            int ret = 0;
            if ((s.Count == 1) && (d == s[0])) { return 1; } 
            //m elemű szubarrayokat keresünk, amelyek elemeinek összege d
            for (int i = 0; i <= s.Count - m + 1; i++)
            {
                int[] sub_arr = s.Skip(i).Take(m).ToArray();
                if (sub_arr.Sum() == d) { ret++; }
            }
            return ret;
        }
    }
}
