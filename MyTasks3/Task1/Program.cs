using System.Collections.Generic;
using static System.Console;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero archer = new Archer(1, "Mike", 20);
            Hero gunman = new Gunman(2, "Alise");
            Hero wizard = new Wizard(3, "Gendalf", 1000);
            Hero swordsman = new Swordsman(4, "Guts", 1);
            WriteLine("-------------------------------");

            List<Hero> heroes = new List<Hero> { archer, gunman, wizard, swordsman };

            heroes.ForEach(h => h.Attack());
            WriteLine("-------------------------------");
            heroes.ForEach(h => h.Move());
            WriteLine("-------------------------------");
            heroes.ForEach(h => h.Speak());
            WriteLine("-------------------------------");

            ReadLine();
        }
    }
}
