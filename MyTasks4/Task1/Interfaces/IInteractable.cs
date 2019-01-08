namespace Task1.Interfaces
{
    public interface IInteractable
    {
        void TakeItem();
        void TakeItem(string name);
        void GiveItem();
        void GiveItem(string name);
    }
}
