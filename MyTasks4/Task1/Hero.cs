using System;
using Task1.Interfaces;
using static System.Console;

namespace Task1
{
    public abstract class Hero : IInteractable, IMoveable, IComparable<Hero>, IEquatable<Hero>
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
            WriteLine("Hello from Finalizer!!!");
            _count--;
        }

        public override string ToString()
        {
            return $"-Id:{Id}\n-Name:{Name}\n-Level:{Level}\n-Speed:{Speed}\n-Energy:{Energy}\n-Strength:{Strength}\n\n";
        }

        public abstract void Move();

        public abstract void Speak();

        public abstract void Attack();

        public virtual void TakeItem()
        {
            WriteLine("Take some items!!");
        }

        public virtual void TakeItem(string itemName)
        {
            WriteLine($"Take a(an) {itemName} item!!");
        }

        public virtual void GiveItem()
        {
            WriteLine("I've just given a random item!!");
        }

        public virtual void GiveItem(string itemName)
        {
            WriteLine($"I've just given a(an) {itemName} item!!");
        }

        public virtual void GoToLocation(string locationName)
        {
            WriteLine($"{Name}'s new location: {locationName}");
        }

        public int CompareTo(object obj)
        {
            Hero h = obj as Hero;
            if (h != null)
            {
                if (Id == h.Id && Name == h.Name)
                    return 0;
                else if (Id < h.Id)
                    return -1;
                else
                    return 1;
            }
            else
                throw new ArgumentNullException();
        }

        public bool Equals(Hero other)
        {
            if (other == null)
                return false;
            Hero h = other as Hero;
            if (Id == h.Id)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Hero h = obj as Hero;
            if (h == null)
                return false;
            else
                return Equals(h);
        }

        public int CompareTo(Hero other)
        {
            if (Id == other.Id && Name == other.Name)
                return 0;
            else if (Id < other.Id)
                return -1;
            else
                return 1;
        }

        public static bool operator ==(Hero h1, Hero h2)
        {
            if (((object)h1) == null || ((object)h2) == null)
                return Equals(h1, h2);
            return h1.Equals(h2);
        }

        public static bool operator !=(Hero h1, Hero h2)
        {
            if (((object)h1) == null || ((object)h2) == null)
                return !Equals(h1, h2);
            return !(h1.Equals(h2));
        }
    }
}
