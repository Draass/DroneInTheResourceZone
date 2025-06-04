namespace _Project.Scripts.Logic.Interfaces.Game
{
    public interface IResourceCollectionService
    {
        void CollectResource(int id);
        
        bool IsOccupied(int id);
        
        void SetOccupied(int id, bool value);
    }
}