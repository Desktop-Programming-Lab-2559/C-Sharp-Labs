using System;
using System.Linq;

using static System.Console;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Камень-ножницы-бумага";
            // метод Split разделяет строку на подстроки используя сепаратор тире('-') т.е. в рез-те этой операции
            // у нас будет массив строк({"Камень", "ножницы", "бумага"}) теперь с помощью Select(s => s.ToLower())
            // приводим каждый элемент массива строк к нижнему регистру и преобразуем в массив строк обратно
            string[] arr = str.Split(new char[] { '-' }).Select(s => s.ToLower()).ToArray();
            int playerScore = 0;            // переменная для подсчета очков игрока
            int computerScore = 0;          // и компьютера
            const int N = 3;                // константа для установки количества повторений в игре
            Random rnd = new Random();      // класс для генерации случайных чисел

            for (int i = 0; i < N; i++)
            {
                WriteLine("---------------------------------");
                string computer = arr[rnd.Next(0, 3)];  // rnd.Next(0, 3) генерирует случайное число в диапазоне 
                WriteLine("Камень-ножницы-бумага!");
                WriteLine("Введите слово (камень, ножницы или бумага): ");
                string player = ReadLine().ToLower();
                WriteLine($"Вы выбрали - {player}, а компьютер - {computer}"); // $ - интерполяция строк(более удобный для форматирования)
                // логика игры
                if (player == "камень")
                {
                    if (computer == "ножницы")
                        ++playerScore;
                    else if (computer == "бумага")
                        ++computerScore;
                }
                else if (player == "ножницы")
                {
                    if (computer == "камень")
                        ++computerScore;
                    else if (computer == "бумага")
                        ++playerScore;
                }
                else if (player == "бумага")
                {
                    if (computer == "камень")
                        ++playerScore;
                    else if (computer == "ножницы")
                        ++computerScore;
                }
            }
            // выводим победителя
            if (playerScore > computerScore)
                WriteLine("Вы выиграли!");
            else if (computerScore > playerScore)
                WriteLine("Компьютер выиграл у Вас!");
            else
                WriteLine("Боевая ничья!");

            ReadKey();
        }
    }
}
