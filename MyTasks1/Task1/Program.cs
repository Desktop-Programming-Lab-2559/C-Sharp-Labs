﻿using static System.Console;

namespace Task1
{
    class Program // класс Program(можем называть как угодно)
    {
        static void Main(string[] args)                     // основной метод Main который принимает строку и ничего неВозвращает  
        {
            string str1 = "Я буду усердно делать все задания по C# и заниматься дома"; // объявляем и присваиваем значение строке str1
            string str2 = "За это ты получишь печеньку";    // объявляем и присваиваем значение строке str2
            bool flag = true;                               // объявляем и присваиваем значение переменной flag, которая будет управлять циклом

            while (flag)                        // цикл будет повторяться пока переменная flag = true
            {
                WriteLine("Введите строку: ");  // выводим на консоль с помощью метода WriteLine 
                string str = ReadLine();        // читаем введенную строку из консоли и присваеваем ее str

                if (str == str1)                // проверяем равенство строк по значению
                {                               // если они равны то 
                    WriteLine(str2);            // выводим на консоль сообщение
                    flag = false;               // чтоБы выйти из цикла
                }
                else
                    Clear();                    // иначе очищаем консоль и цикл повторяется заново
            }

            ReadKey(); // читает символ         // задержка перед выходом(если юзаешь CTRL+F5 то эта строка лишняя)
        }
    }
}
