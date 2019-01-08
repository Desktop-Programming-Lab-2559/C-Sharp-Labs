
using static System.Console;

namespace ConsoleCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser p = new Parser();
            WriteLine(p.Evaluate("30 + 40 - (20 - 80) * 2"));
        }
    }
}
