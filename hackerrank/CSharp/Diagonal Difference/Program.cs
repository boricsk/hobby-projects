/*
 Adott egy négyzetmátrix, számítsa ki az abszolút különbséget az átlói összegei között.

Például a négyzetmátrix lent látható:
1 2 3
4 5 6
9 8 9

Bal átló:
1+5+9 = 15

Jobb átló:
3+5+9 = 17

A különbség : ABS(15-17) = 2

 */
static int diagonalDifference(List<List<int>> arr)
{
    int diagonal_lr = 0;
    int diagonal_rl = 0;
    int j = arr.Count - 1;
    
    
    for (int i = 0; i < arr.Count; i++)
    {
        diagonal_lr += arr[i][i];
        diagonal_rl += arr[i][j];
        j--;
    }
    return Math.Abs(diagonal_lr - diagonal_rl);
}

List<List<int>> input = new List<List<int>>();
input.Add(new List<int> { 1, 2, 3 });
input.Add(new List<int> { 4, 5, 6 });
input.Add(new List<int> { 9, 8, 9 });

diagonalDifference(input);