using System;
using static System.Console;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] arr1 = new int[10];
            int[] arr2 = new int[10];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rnd.Next(-5, 10);
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = rnd.Next(-5, 10);
            }

            WriteLine("Массив arr1:");
            Array.ForEach(arr1, e => Write($" {e} "));

            WriteLine("\nМассив arr2:");
            Array.ForEach(arr2, e => Write($" {e} "));

            Array.Sort(arr2);       // сортируем массив
            Array.Reverse(arr2);    // делаем риверс массива
            WriteLine("\nОтсортированный в обратном порядке массив arr2:");
            Array.ForEach(arr2, e => Write($" {e} "));

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = arr1[i] + arr2[i];
            }
            WriteLine("\nКонечный массив arr2:");
            Array.ForEach(arr2, e => Write($" {e} "));

            ReadKey();
        }
    }
}
