/*
Van egy nagy halom zokni, amelyet szín szerint kell párosítani. 
Adott egy egész számok tömbje, amely minden zokni színét 
reprezentálja, határozza meg, hogy hány pár egyező színű zokni van.

Példa:

n = 7

ar = [1,2,1,2,1,3,2]
Van egy 1-es és egy 2-es színpár. Három páratlan zokni maradt, mindegyik színből egy. A párok száma 2.
*/
namespace sales_by_match
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            Console.WriteLine(sockMerchant(9,list));
        }

        public static int sockMerchant(int n, List<int> ar)
        {
            int ret = 0;
            List<int> pairs = new List<int>();
            foreach (int i in ar) 
            {
                if (!pairs.Contains(i))
                {
                    pairs.Add(i);
                } else
                {
                    ret++;
                    pairs.Remove(i);
                }
            }
            return ret;
        }
    }
}
