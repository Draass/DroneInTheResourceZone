using _Project.Scripts.Logic.Interfaces.Game;

namespace _Project.Scripts.Logic.Game
{
    public class FactionService : IFactionService
    {
        public int CollectedResources { get; private set; }
        
        public void AddResource(int amount)
        {
            CollectedResources += amount;
        }

        public void RemoveResource(int amount)
        {
            CollectedResources -= amount;
        }
    }
}