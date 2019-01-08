using static System.Console;

namespace Task1
{
    public sealed class Wizard : Hero
    {
        public double Mana { get; set; }

        public Wizard(int id, string name, double mana = 100) : base(id, name)
        {
            Mana = mana;
            WriteLine($"Gunman {name} is created!");
        }

        private void MagicBallAttack()
        {
            WriteLine($"{Name} is attacking with his magic ball");
        }

        public override void Attack()
        {
            WriteLine($"My name is {Name}, and I'am a(an) {GetType().Name}");
            MagicBallAttack();
            Mana -= 50;
        }

        public override void Move()
        {
            WriteLine($"Wizard {Name} is moving");
        }

        public override void Speak()
        {
            WriteLine($"Wizard {Name} is speaking");
        }
    }
}
