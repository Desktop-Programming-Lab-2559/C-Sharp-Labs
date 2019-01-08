using System;
using System.Threading;

using static System.Console;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = WindowHeight;  // получаем высоту консольного окна
            int width = WindowWidth;    // получаем ширину консольного окна
            
            Random rnd = new Random();  // Random - для генерации рандомных чисел
            bool flag = true;           // флаг для контроля цикла
            while (flag)
            {
                // устанавливаем рандомное положение курсора консоли но в пределах нашего окна
                SetCursorPosition(rnd.Next(1, width), rnd.Next(1, height));
                ForegroundColor = (ConsoleColor)rnd.Next(0, 15); // устанавливаем рандомный цвет текста консоли
                WriteLine("C#");
                Thread.Sleep(100);  // задержка в 100 ms

                if (KeyAvailable)   // если нажата хоть какая-нибудь клавиша клавиатуры
                {
                    ConsoleKeyInfo key = ReadKey(false);     // читаем эту клавишу
                    if (key.Key == ConsoleKey.Escape)        // если это - ESC, то меняем флаг и выходим  
                        flag = false;
                }
            }
        }
    }
}
