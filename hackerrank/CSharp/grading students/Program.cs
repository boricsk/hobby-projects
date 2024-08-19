/*
A HackerLand Egyetem a következő minősítési szabályzattal rendelkezik:

-Minden tanuló 0-tól 100-ig terjedő osztályzatot kap.
-Minden 40-nél kisebb osztályzat bukott osztályzatnak minősül.

Sam az egyetem professzora, és szereti minden diák érdemjegyét a következő szabályok szerint kerekíteni:

-Ha a fokozat és az 5 következő többszöröse közötti különbség kisebb, mint 3, kerekítse a fokozatot az 5 következő többszörösére.
-Ha az osztályzat értéke kisebb, mint 38, akkor nem történik kerekítés, mivel az eredmény továbbra is nem megfelelő osztályzat lesz.

Adva a gradle kezdeti értékét Sam minden tanítványánál, írjon kódot a kerekítési folyamat automatizálásához. 

Példák
gradle = 84 felkerekít 85-re (85-84 kevesebb mint 3)
gradle = 29 nem kerekít (29 kevesebb mint 40)
gradle = 57 nem kerekít (60 - 57 3 vagy nagyobb)

*/

static List<int> gradingStudents(List<int> grades)
{
    List<int> result = new List<int>();

    foreach (int grade in grades) 
    {
        if (grade >= 38)
        {
            if (nextDivByFive(grade) - grade < 3) 
            { 
                result.Add(nextDivByFive(grade)); 
            }
            else
            {
                result.Add(grade);
            }
        }
        else 
        { 
            result.Add(grade); 
        }
        
    }
        return result;
}

static int nextDivByFive(int div)
{
    int result = 0;
    for (int i = 0; i < 5; i++) 
    {
        if (((i + div) % 5) == 0) {result =  i + div; }
    }
    return result;
}

List<int> gradles = new List<int>();

gradles.Add(73);
gradles.Add(67);
gradles.Add(38);
gradles.Add(33);

gradingStudents(gradles);