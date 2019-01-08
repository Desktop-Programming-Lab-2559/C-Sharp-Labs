using System.Collections.Generic;
using Task1.Interfaces;
using static System.Console;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IMoveable> moveables = new List<IMoveable> {
                new Swordsman(1, "Guts"),
                new Wizard(2, "Gendalf"),
                new Gunman(3, "Pointman"),
                new NPC(4, "CopperHead"),
                new Archer(5, "Lucy")
            };
            WriteLine("-------------------------");
            moveables.ForEach(m => m.Move());
            WriteLine("-------------------------");
            moveables.ForEach(m => m.GoToLocation("Wild Land"));
            WriteLine("-------------------------");
            //WriteLine(moveables[0] as Hero == moveables[1] as Hero);
        }
        
    }
}
