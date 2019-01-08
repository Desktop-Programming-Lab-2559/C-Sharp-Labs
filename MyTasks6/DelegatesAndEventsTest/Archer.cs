using System;
using static System.Console;

namespace DelegatesAndEventsTest
{
    public sealed class Archer : Hero
    {
        public int NumOfArrows { get; set; }

        public Archer(int id, string name, int numOfArrows = 40) : base(id, name)
        {
            NumOfArrows = numOfArrows;
            //WriteLine($"Archer {name} is created!");
        }

        private void BowAttack()
        {
            WriteLine($"{Name} is attacking with his bow");
        }

        public override void Attack()
        {
            WriteLine($"My name is {Name}, and I'am a(an) {GetType().Name}");
            BowAttack();
            NumOfArrows -= 1;
        }

        public override void Move()
        {
            WriteLine($"Archer {Name} is moving");
        }

        public override void Speak(Action speak)
        {
            if (speak != null)
                speak();
            else
                WriteLine($"Archer {Name} is speaking");
        }
    }
}
