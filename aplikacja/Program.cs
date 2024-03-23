using System;

public class Statistics
{
    public static double CalculateAverage(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
        {
            throw new ArgumentException("Tablica nie może być pusta.");
        }

        long sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return (double)sum / numbers.Length;
    }
}