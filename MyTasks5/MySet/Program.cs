using Task1;
using static System.Console;

namespace MySet
{
    class Program
    {
        static void Main(string[] args)
        {
            MySet<int> set1 = new MySet<int> { 1, 2, 3, 4 };
            MySet<int> set2 = new MySet<int> { 3, 4, 5, 6 };
            
            WriteLine("--UNION");
            MySet<int> newSet = set1.Union(set2);
            newSet.Show();
            WriteLine();
            newSet = set1 + set2;
            newSet.Show();

            WriteLine("\n--INTERSECT");
            newSet = set1.Intersect(set2);
            newSet.Show();
            WriteLine();
            newSet = set1 * set2;
            newSet.Show();

            WriteLine("\n--DIFFERENCE");
            newSet = set1.Difference(set2);
            newSet.Show();
            WriteLine();
            newSet = set1 - set2;
            newSet.Show();

            WriteLine("\n--SYM DIFFERENCE");
            newSet = set1.SymmetricDifference(set2);
            newSet.Show();
            WriteLine();
            newSet = set1 % set2;
            newSet.Show();

            WriteLine("\n--IS SUBSET");
            MySet<int> s1 = new MySet<int> { 1, 2, 6 };
            MySet<int> s2 = new MySet<int> { 3, 5, 8, 4 };
            MySet<int> s3 = new MySet<int> { 3, 4, 5, 6, 7, 8 };
            WriteLine($"s1 Is Subset of s3 : {s1.IsSubset(s3)}");
            WriteLine($"s1 Is Subset of s3 (s1 < s3) : {s1 < s3}");
            WriteLine($"s2 Is Subset of s3 : {s2.IsSubset(s3)}");
            WriteLine($"s2 Is Subset of s3 (s3 > s2) : {s3 > s2}");
            WriteLine();

            WriteLine("---------Hero objects------------");
            MySet<Hero> h1 = new MySet<Hero> { new Swordsman(1, "Guts"), new Wizard(2, "Gendalf"), new Gunman(3, "Pointman") };
            MySet<Hero> h2 = new MySet<Hero>
            {
                new Swordsman(1, "Guts"),
                new Wizard(2, "Gendalf"),
                new Gunman(3, "Pointman"),
                new Archer(4, "Lucy"),
                new Wizard(5, "Merlin"),
            };
            WriteLine("--Hero UNION");
            MySet<Hero> h3 = h1.Union(h2); // h3 = h1 + h2;
            h3.Show();

            WriteLine("\n--Hero INTERSECT");
            h3 = h1.Intersect(h2); // h3 = h1 * h2;
            h3.Show();
            WriteLine();

            WriteLine("\n--Hero DIFFERENCE");
            h3 = h2.Difference(h1); // h3 = h1 - h2;
            h3.Show();

            WriteLine("\n--Hero SYM DIFFERENCE");
            h3 = h1.SymmetricDifference(h2); // h3 = h1 % h2;
            h3.Show();
        }
    }
}
