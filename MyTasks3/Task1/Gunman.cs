using static System.Console;

namespace Task1
{
    public sealed class Gunman : Hero
    {
        public int NumOfBullets { get; set; }

        public Gunman(int id, string name, int numOfBullets = 20) : base(id, name)
        {
            NumOfBullets = numOfBullets;
            WriteLine($"Gunman {name} is created!");    
        }

        private void GunAttack()
        {
            WriteLine($"{Name} is attacking with his gun");
        }

        public override void Attack()
        {
            WriteLine($"My name is {Name}, and I'am a(an) {GetType().Name}");
            GunAttack();
            NumOfBullets -= 1;
        }

        public override void Move()
        {
            WriteLine($"Gunman {Name} is moving");
        }

        public override void Speak()
        {
            WriteLine($"Gunman {Name} is speaking");
        }
    }
}
