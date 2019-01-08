namespace DelegatesAndEventsTest.Interfaces
{
    public delegate void DelRaid();
    public interface IInteractable
    {
        event DelRaid AddRaid;
        void TakeItem();
        void TakeItem(string name);
        void GiveItem();
        void GiveItem(string name);
    }
}
