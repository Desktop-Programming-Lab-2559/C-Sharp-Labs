using static System.Console;

namespace Task1
{
    public sealed class Swordsman : Hero
    {
        public int NumOfSwords { get; set; }
        
        public Swordsman(int id, string name, int swordsCount = 2) : base(id, name)
        {
            NumOfSwords = swordsCount;
            WriteLine($"Swordsman {name} is created!");
        }

        private void SwordAttack()
        {
            WriteLine($"{Name} is attacking with his sword");
        }

        public override void Attack()
        {
            WriteLine($"My name is {Name}, and I'am a(an) {GetType().Name}");
            SwordAttack();
        }

        public override void Move()
        {
            WriteLine($"Swordsman {Name} is moving");
        }

        public override void Speak()
        {
            WriteLine($"Swordsman {Name} is speaking");
        }
    }
}
