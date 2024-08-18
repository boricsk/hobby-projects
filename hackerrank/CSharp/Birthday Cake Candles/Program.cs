/*
You are in charge of the cake for a child's birthday. 
You have decided the cake will have one candle for each year of their total age. 
They will only be able to blow out the tallest of the candles. Count how many candles are tallest. 

Example:
candles = [4,4,1,3]
The maximum height candles are 4 units high. There are 2 of them, so return 2.

 */


static int birthdayCakeCandles(List<int> candles)
{
    int max = candles.Max();    
    //a max érték előfordulásának száma a listában
    return candles.Count(x => x == max);
}

List<int> candles =  new List<int>();
candles.Add(4);
candles.Add(4);
candles.Add(1);
candles.Add(3);

Console.Write(birthdayCakeCandles(candles));