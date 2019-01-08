using System;
using System.Linq;
using static System.Console;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Kazimirov";//"Мурсапилами";
            var result = str.Select(c => new
            {
                @Char = c,
                Code = (int)c,
                Count = str.Where(ch => ch == c).Count()
            }).Distinct().Sum(e => Math.Pow(e.Code, e.Count)) % 8;
            //foreach (var item in result)
            //{
            //    WriteLine($"{item.Char}-{item.Code}-{item.Count}");
            //}
            WriteLine($"Final result: {result}"); // 3 - Hero
            ReadKey();
        }
    }
}
