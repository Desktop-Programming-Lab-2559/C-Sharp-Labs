using System;
using System.Linq;

using static System.Console;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-5, 10);
            }
            WriteLine("Массив arr:");
            Array.ForEach(arr, e => Write($" {e} "));

            var tuple = MinMaxAvg(arr); // кортеж
            WriteLine($"\nMin: {tuple.Item1}\nMax: {tuple.Item2}\nAverage: {tuple.Item3}");
            ReadKey();
        }

        static (int, int, double) MinMaxAvg(int[] arr)
        {
            int min = arr.Min(); //Min(arr);
            int max = arr.Max(); //Max(arr);
            double avg = arr.Average(); //Avg(arr);
            var tuple = (min, max, avg);
            return tuple;
        }

        static int Min(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < result)
                    result = arr[i];
            }
            return result;
        }

        static int Max(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > result)
                    result = arr[i];
            }
            return result;
        }

        static double Avg(int[] arr)
        {
            double result = 0.0d;
            int sum = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                    ++count;
                }
            }
            result = (double)sum / count;
            return result;
        }
    }
}
