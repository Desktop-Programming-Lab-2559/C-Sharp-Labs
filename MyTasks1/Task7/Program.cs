using System;
using System.Linq;

using static System.Console;

namespace Task7
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

            WriteLine("\nНовый массив:");
            //var test = arr.Except(new int[] { 3, 4, 5, 6, 7 }).ToArray();
            //Array.ForEach(test, e => Write($" {e} "));
            foreach (var item in NewArray(arr, 3, 4, 5, 6, 7))
            {
                Write($" {item} ");
            }
            WriteLine();
            ReadKey();
        }
        // возвращает целочисленный массив без элементов со значениями, переданными в качестве набора параметров
        static int[] NewArray(int[] arr, params int[] numbers)
        {
            int size = 0; // счетчик который будет хранить размер нового массива
            // временный массив который будет использован как шаблон индексов(false - добавляем, true - пропускаем) 
            bool[] tmp = new bool[arr.Length]; // по умолчанию все значения false

            for (int i = 0; i < arr.Length; i++)
            {
                bool isExist = false; // временная переменная для помощи в нахождении размера нового массива
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (arr[i] == numbers[j])
                    {
                        isExist = true; // если isExist == true то ничего не делаем
                        tmp[i] = true;
                        break;
                    }
                }
                if (isExist == false) // если isExist == false то увеличиваем счетчик размера нового массива
                    ++size;
            }
            int[] newArr = new int[size]; // создаем новый массив
            for (int i = 0, k = 0; i < arr.Length; ++i)
            {
                if (tmp[i] == false)
                    newArr[k++] = arr[i]; // и заполняем его если tmp[i] == false
            }
            return newArr;
        }
    }
}
