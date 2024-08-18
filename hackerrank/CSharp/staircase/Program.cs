/*

n = 4

   #
  ##
 ###
####

Its base and height are both equal to. It is drawn using # symbols and spaces. The last line is not preceded by any spaces.

Write a program that prints a staircase of size n. 
 
 */
static void staircase(int n)
{
    for (int i = 1; i <= n; i++)
    {
        Console.WriteLine(new string(' ', n-i) +  new string('*', i));
        //ha 0-ról indul a for egy szóköz ott marad az elején.
    }
}

staircase(4);
