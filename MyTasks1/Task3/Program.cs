using System;

using static System.Console;
using static System.Math;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите число n для подсчета суммы n-членов первого и второго ряда:");
            int n = int.Parse(ReadLine());
            WriteLine($"Сумма {n} - членов первого ряда равна: {Series1(n):0.##}"); // :0.## - два числа после запятой
            WriteLine($"Сумма {n} - членов второго ряда равна: {Series2(n):0.##}"); // :0.## - два числа после запятой
            ReadKey();
        }

        // метод для подсчета суммы n-членов первого ряда
        static double Series1(int n)
        {
            double sum = 0.0d;
            // сокращенная локальная функция для подсчета факториала числа
            int Factorial(int number) => (number == 0 || number == 1) ? 1 : number * Factorial(number - 1);

            // подсчет суммы ряда
            for (int i = 0; i < n; i++)
            {
                sum += (1 / Convert.ToDouble(Factorial(i)));
            }

            return sum;
        }
        // метод для подсчета суммы n-членов второго ряда
        static double Series2(int n)
        {
            double sum = 0.0d;
            for (int i = 0; i < n; i++)
            {
                sum += (Pow(-1, i) / (2 * i + 1)); // Math.Pow - возводит число -1 в степень i
            }

            return 4 * sum;
        }
    }
}
