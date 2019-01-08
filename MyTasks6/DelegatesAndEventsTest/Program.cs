using System.Collections.Generic;
using static System.Console;

namespace DelegatesAndEventsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>
            {
                new Swordsman(1, "Guts"),
                new Wizard(2, "Gendalf"),
                new Gunman(3, "Pointman"),
                new Archer(4, "Lucy"),
                new Wizard(5, "Merlin"),
            };
            WriteLine("----Heroes Callbacks----");
            heroes.ForEach(h => h.Speak(() => WriteLine($"Hello, My name is {h.Name}!!!")));
            WriteLine("----Subscribe Heroes to Raid----");
            heroes.ForEach(h => h.AddRaid += NewRaid);
            heroes.ForEach(h => h.GoToRaid());
            WriteLine("----Unsubscribe Heroes to Raid----");
            heroes.ForEach(h => h.AddRaid -= NewRaid);
            heroes.ForEach(h => h.GoToRaid());
        }
        static void NewRaid()
        {
            WriteLine($"Attention, Heroes! New Raid was announced!!!!");
        }
    }
}
