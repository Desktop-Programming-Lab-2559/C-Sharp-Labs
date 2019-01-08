using static System.Console;

namespace Task1
{
    public abstract class Hero
    {
        private static int _count;
        private readonly int id;

        public static int Count { get { return _count; } }
        public int Id { get { return id; } }
        public string Name { get; set; }
        public int Level { get; set; }
        public double Speed { get; set; }
        public double Energy { get; set; }
        public int Strength { get; set; }

        static Hero()
        {
            _count = 0;
        }

        public Hero(int id = 0, string name = "", int level = 0,
                    double speed = 0.0, double energy = 0.0, int strength = 0)
        {
            WriteLine("Hello from constructor!!!!");
            this.id = id;
            Name = name;
            Level = level;
            Speed = speed;
            Energy = energy;
            Strength = strength;
            _count++;
        }

        ~Hero()
        {
            WriteLine("Hello from Finalizator!!!");
            _count--;
        }

        public override string ToString()
        {
            return $"-Id:{Id}\n-Name:{Name}\n-Level:{Level}\n-Speed:{Speed}\n-Energy:{Energy}\n-Strength:{Strength}";
        }

        public abstract void Move();

        public abstract void Speak();

        public abstract void Attack();

        public virtual void TakeItem()
        {
            WriteLine("I've just take some items!!");
        }

        public virtual void TakeItem(string itemName)
        {
            WriteLine($"I've just take {itemName} item!!");
        }

        public virtual void GiveItem()
        {
            WriteLine("I've just give a random item!!");
        }

        public virtual void GiveItem(string itemName)
        {
            WriteLine($"I've just give a(an) {itemName} item!!");
        }

        public virtual void GoToNextLocation(string locationName)
        {
            WriteLine($"My new location: {locationName}");
        }
    }
}
