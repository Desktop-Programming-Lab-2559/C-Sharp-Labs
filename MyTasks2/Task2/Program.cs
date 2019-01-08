using static System.Console;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero1 = new Hero(1, "NewWarrior", 1, 4.2, 10.5, 20);
            hero1.GoToNextLocation("Black Desert");
            hero1.TakeItem();
            hero1.TakeItem("Lightsaber");
            Hero hero2 = hero1;
            //WriteLine(Hero.Count);
            WriteLine(hero1);
            WriteLine();
            WriteLine(hero2);
        }
    }
}
