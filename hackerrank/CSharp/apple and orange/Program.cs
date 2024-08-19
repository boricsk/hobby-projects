/*
Sam házában van egy almafa és egy narancsfa, amelyek rengeteg gyümölcsöt hoznak. 
Az alábbi információk alapján határozza meg, hány alma és narancs landol Sam házában.

Az alábbi diagramon:

A piros régió a házat jelöli, ahol s a kezdőpont, és t a végpont. 
Az almafa a háztól balra, a narancsfa pedig jobbra van.
Tegyük fel, hogy a fák egyetlen ponton helyezkednek el, 
ahol az almafa az a pontban, a narancsfa pedig a b pontban van.
Amikor egy gyümölcs leesik a fájáról, d egységnyi távolságra landol 
a származási fájától az x tengely mentén. 
(A d negatív értéke azt jelenti, hogy a gyümölcs d egységnyit a fától balra, 
a pozitív d azt jelenti, hogy d egységgel jobbra esik a fától.)

Adott d értéke m almára és n narancsra, határozza meg, hány alma és narancs esik Sam házára (azaz az [s,t] tartományba)?

Példa 

Sam háza s=7 és t=10 között van. 
Az almafa a = 4-nél, a narancs a b=12-nél található. 
Van m = 3 alma és n = 3 narancs. 
Az almák apple = [2,3,-4] egységnyi távolságra, 
a narancsok pedig [3,-2,-4] egységnyi távolságra esnek le. 

Minden alma távolságot hozzáadva a fa helyzetéhez, a [4+2;4+3;4+(-4)] = [6,7,0] pontnál landolnak. 
A narancsok [12+3;12+(-2);12+(-4)] = [15,10,8] helyen landolnak. 

Egy alma és két narancs a 7-10-es tartományba esik, így nyomtatunk:

1
2 
*/

/*
 * Complete the 'countApplesAndOranges' function below.
 *
 * The function accepts following parameters:
 *  1. INTEGER s (Ház kezdőpont)
 *  2. INTEGER t (Ház végpont)
 *  3. INTEGER a (Almafa helye)
 *  4. INTEGER b (Narancsfa helye)
 *  5. INTEGER_ARRAY apples (Almák landolási helyei)
 *  6. INTEGER_ARRAY oranges (Narancsok landolási helyei)
 */

static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
{
    List<int> apple_landing = new List<int>();
    List<int> orange_landing = new List<int>();
    int num_of_apple = 0;
    int num_of_orange = 0;
    foreach (int apple in apples)
    {
        apple_landing.Add(apple + a);
    }
    foreach (int orange in oranges)
    {
        orange_landing.Add(orange + b);
    }

    //s és t közti értékek hányan vannak
    foreach (int apple in apple_landing)
    {
        if (apple >= s && apple <= t) { num_of_apple++; }
    }
    foreach (int orange in orange_landing)
    {
        if (orange >= s && orange <= t) { num_of_orange++; }
    }

    Console.WriteLine(num_of_apple);
    Console.WriteLine(num_of_orange);
}

List<int> apples = new List<int>();
List<int> oranges = new List<int>();

apples.Add(2);
apples.Add(3);
apples.Add(-4);

oranges.Add(3);
oranges.Add(-2);
oranges.Add(-4);

countApplesAndOranges(7,10,4,12,apples,oranges);