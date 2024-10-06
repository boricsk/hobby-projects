/*
Maria egyetemi kosárlabdázik, és profi akar lenni. Minden szezonban rekordot 
vezet a játékáról. Bemutatja, hányszor döntötte meg szezonbeli rekordját a 
legtöbb és a legkevesebb pontért egy meccsen. Az első meccsen szerzett 
pontok rögzítik a szezon rekordját, és onnantól kezdi a számolást.

Példa
scores = [12,24,10,24]

A pontszámok a lejátszott játékok sorrendjében vannak. Eredményeit a 
következő táblázatba foglalja:

                                     Count
    Game  Score  Minimum  Maximum   Min Max
     0      12     12       12       0   0
     1      24     12       24       0   1
     2      10     10       24       1   1
     3      24     10       24       1   1

Az adott szezon pontszámait figyelembe véve határozza meg, hányszor dönti 
meg Maria a szezon során szerzett legtöbb és legkevesebb pont rekordját.

Bemenet
9
10 5 20 20 4 5 2 25 1

Kimenet
2 4

                                     Count
    Game  Score  Minimum  Maximum   Min Max
     0      10     10       10       0   0
     1      05     05       10       1   0
     2      20     05       20       0   1
     3      20     05       20       0   0
     4      04     04       20       1   0
     5      05     04       20       0   0
     6      02     02       20       1   0
     7      25     02       25       0   1
     8      01     01       25       1   0

Legjobb rekordját kétszer döntötte meg (a 2. és 7. játszma után), míg a 
legrosszabb rekordját négyszer (az 1., 4., 6. és 8. játszma után), ezért 
válaszunkként 2 4-et nyomtatunk. Ne feledje, hogy a játék során nem döntötte 
meg a legjobb pontszámot elérő rekordját, mivel a játék során elért pontszáma 
nem volt szigorúan magasabb, mint akkori legjobb rekordja.

 */

namespace breaking_the_records
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int> { 10, 5, 20, 20, 4, 5, 2, 25, 1};
            breakingRecords(test);
        }

        public static List<int> breakingRecords(List<int> scores)
        {
            List<int> ret = new List<int> { 0, 0 };
            int min_tmp = scores[0];
            int max_tmp = scores[0];
            ret[0] = 0;
            ret[1] = 0;

            for (int i = 1; i < scores.Count; i++)
            {
                //Azért van fordítva, mert az 1. elemnek a + rekord döntéseket kell mutatni, a másodiknak a - rekord döntéseket
                if (scores[i] > min_tmp) { ret[0]++; min_tmp = scores[i]; }
                if (scores[i] < max_tmp) { ret[1]++; max_tmp = scores[i]; }
            }
            //Console.WriteLine(ret[0]);
            //Console.WriteLine(ret[1]);
            return ret;

        }
    }
}
