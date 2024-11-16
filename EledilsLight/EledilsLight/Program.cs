namespace EledilsLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tunde t = new Tunde(10);
            t.RunSimulation();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(t.isTurn[i]);
            }
        }
    }
}
