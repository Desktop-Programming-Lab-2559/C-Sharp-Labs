using System;

using static System.Console;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int numOfErrors = 0;
            Random rnd = new Random();
            // получаем массив значений элементов из которых состоит перечисление ConsoleKey  
            var keys = Enum.GetValues(typeof(ConsoleKey));  //ConsoleKey - клавиши консоли

            do
            {
                // получаем случайное значение клавиши консоли типа object из массива keys
                var key = keys.GetValue(rnd.Next(0, keys.Length));
                int tmpKey = (int)key; // приводим к типу int для более простой проверки
                if (tmpKey > 123 || (tmpKey > 90 && tmpKey < 96) || (tmpKey < 48)) // если не соответствует условию
                    continue;   // то переходим на следующую итерацию цикла
                WriteLine($"Нажмите клавишу: {key}");
                ConsoleKeyInfo pressedKey = ReadKey(true); // читаем(набираем) клавишу консоли

                if (pressedKey.Key == (ConsoleKey)key) // если клавиши(которую нужно ввести и которую мы ввели) совпадают
                {
                    ++count;
                    if (count == 20)
                    {
                        WriteLine("Вы справились с задачей!!!!!");
                        break;
                    }
                }
                else // если нет
                {
                    count = 0;
                    ++numOfErrors;
                    if (numOfErrors == 3)
                    {
                        WriteLine("Слишком много ошибок - это конец!!!!!");
                        break;
                    }

                }
            } while (true);
        }
    }
}
