/*
Given an array of integers and a positive integer k, determine the number of (i,j)  pairs where i < j and ar[i] + ar[j] is divisible by k.

Example
STDIN           Function
-----           --------
6 3             n = 6, k = 3
1 3 2 6 1 2     ar = [1, 3, 2, 6, 1, 2]

Output 5

(0,2) = 1+2
(0,5) = 1+2
(1,3) = 3+6
(2,4) = 2+1
(4,5) = 1+2
*/
namespace Divisible_Sum_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 3, 2, 6, 1, 2 };

            Console.WriteLine(divisibleSumPairs(6, 3, list));
        }
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int ret = 0;
            for (int i = 0; i < ar.Count; i++)
            {
                for (int j = i; j < ar.Count ; j++)
                {
                    if (i != j)
                    {
                        if ((ar[i] + ar[j]) % k == 0)
                        {
                            ret++;                             
                        }
                    }

                }                
            }
            return ret;
        }
    }
}
