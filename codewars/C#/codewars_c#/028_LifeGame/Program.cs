namespace _028_LifeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[][]
            {
                new int[] { 0, 1, 0 },
                new int[] { 0, 0, 1 },
                new int[] { 1, 1, 1 },
                new int[] { 0, 0, 0 }
            };

            int[][] output = ConwayLife.GetGeneration(input, 1);

            Console.WriteLine(ConwayLife.Htmlize(output));
        }


    }
}
