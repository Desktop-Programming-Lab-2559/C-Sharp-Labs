using DelegatesAndEventsTest.Interfaces;
using static System.Console;

namespace Task1
{
    public class NPC : IInteractable, IMoveable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        protected DelRaid _Raid;
        public event DelRaid AddRaid
        {
            add
            {
                _Raid += value;
            }
            remove
            {
                _Raid -= value;
            }
        }
        public NPC(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void InformAboutRaid()
        {
            DelRaid handler = _Raid;
            if (handler != null)
                handler();
            else
                WriteLine("Sorry, There are no any Raids!!");
        }

        public void TakeItem()
        {
            WriteLine($"{Name} take some items!!");
        }

        public void TakeItem(string itemName)
        {
            WriteLine($"{Name} take a(an) {itemName} item!!");
        }

        public void GiveItem()
        {
            WriteLine($"{Name} give a random item!!");
        }

        public void GiveItem(string itemName)
        {
            WriteLine($"{Name} give a(an) {itemName} item!!");
        }

        public void GoToLocation(string locationName)
        {
            WriteLine($"{Name}'s new location: {locationName}");
        }

        public void Move()
        {
            WriteLine($"{Name} is moving");
        }

    }
}
