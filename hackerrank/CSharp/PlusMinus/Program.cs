/*
 Given an array of integers, calculate the ratios of its elements that are positive, negative, and zero. Print the decimal value of each fraction on a new line with

6 places after the decimal.

Note: This challenge introduces precision problems. The test cases are scaled to six decimal places, though answers with absolute error of up to
are acceptable.


 */

static void plusMinus(List<int> arr)
{
    int arr_len = arr.Count;
    int num_of_pos = 0;
    int num_of_neg = 0;
    int num_of_zero = 0;

    foreach (int i in arr)
    {
        if (i == 0) { num_of_zero++; };
        if (i > 0) { num_of_pos++; };
        if (i < 0) { num_of_neg++; };
    }
    double ratio_of_zero = (double) num_of_zero / arr_len;
    double ratio_of_pos = (double) num_of_pos / arr_len;
    double ratio_of_neg = (double) num_of_neg / arr_len;


    Console.WriteLine(ratio_of_pos.ToString("F6"));
    Console.WriteLine(ratio_of_neg.ToString("F6"));
    Console.WriteLine(ratio_of_zero.ToString("F6"));


}

static void plusMinus2(List<int> arr)
{
    int arr_len = arr.Count;
    int num_of_pos = 0;
    int num_of_neg = 0;
    int num_of_zero = 0;

    foreach (int i in arr)
    {
        switch (i)
        {
            case 0: num_of_zero++; break;
            case > 0: num_of_pos++; break;
            case < 0: num_of_neg++; break;
        }
    }
    double ratio_of_zero = (double)num_of_zero / arr_len;
    double ratio_of_pos = (double)num_of_pos / arr_len;
    double ratio_of_neg = (double)num_of_neg / arr_len;


    Console.WriteLine(ratio_of_pos.ToString("F6"));
    Console.WriteLine(ratio_of_neg.ToString("F6"));
    Console.WriteLine(ratio_of_zero.ToString("F6"));
}

List<int> int_array = new List<int>();

int_array.Add(1);
int_array.Add(1);
int_array.Add(0);
int_array.Add(-1);
int_array.Add(-1);

plusMinus2(int_array);
