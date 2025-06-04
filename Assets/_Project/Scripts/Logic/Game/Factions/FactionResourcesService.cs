using System;
using _Project.Scripts.Logic.Interfaces.Game.Factions;

namespace _Project.Scripts.Logic.Game.Factions
{
    public class FactionResourcesService : IFactionResourcesService
    {
        public int CollectedResources { get; private set; }
        
        public event Action<int> OnResourcesChanged;
        
        public void AddResource(int amount)
        {
            CollectedResources += amount;
            
            OnResourcesChanged?.Invoke(CollectedResources);
        }

        public void RemoveResource(int amount)
        {
            CollectedResources -= amount;
            
            OnResourcesChanged?.Invoke(CollectedResources);
        }
    }
}