using System;

public class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 3, 7, 2, 9, 5, 4, 6, 8 };
        int maxValue = FindMaxValue(numbers);
        Console.WriteLine($"Maksymalna wartość w tablicy to: {maxValue}");
    }

    public static int FindMaxValue(int[] numbers)
    {

        if (numbers == null || numbers.Length == 0)
        {
            throw new ArgumentException("Tablica nie może być pusta.");
        }

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        return max;
    }
}