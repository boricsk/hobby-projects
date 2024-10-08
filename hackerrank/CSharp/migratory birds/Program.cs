/*
Adott egy sor madárészlelést, ahol minden elem egy madártípus 
azonosítót képvisel, határozza meg a leggyakrabban észlelt 
típus azonosítóját. Ha egynél több típust észlelt a maximális 
összeg, adja vissza a legkisebb azonosítót.

Példa
arr = [1,1,2,2,3]
Két-két 1-es és 2-es típusú, valamint egy 3-as típusú megfigyelés 
létezik. A kétszer látható két típus közül válassza ki az 
alsót: 1. típus.

*/
namespace migratory_birds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> birrds = new List<int>() { 1, 1, 2, 2, 3};
            Console.WriteLine(migratoryBirds(birrds));
        }
        public static int migratoryBirds(List<int> arr)
        {
            
            Dictionary<int, int> count = new Dictionary<int, int>();

            foreach (int bird in arr) 
            {
                if (count.ContainsKey(bird))
                {
                    //A value értékét növeli
                    count[bird]++;
                }
                else
                {
                    count.Add(bird, arr.Count(b => b == bird));
                }                
            }

            //foreach (KeyValuePair<int, int> key_value in count)
            //{
            //    Console.WriteLine($"{key_value.Key} {key_value.Value}");
            //}

            // Megkeressük a legnagyobb értéket a dictionary-ben
            int maxValue = count.Values.Max();

            // Kiválasztjuk azokat a kulcs-érték párokat, amelyeknél az érték a legnagyobb
            var maxPairs = count.Where(kv => kv.Value == maxValue);
                        
            return maxPairs.Min(kv => kv.Key);

        }
    }
}
