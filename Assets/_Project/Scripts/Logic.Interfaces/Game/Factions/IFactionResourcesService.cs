using System;

namespace _Project.Scripts.Logic.Interfaces.Game.Factions
{
    public interface IFactionResourcesService
    {
        event Action<int> OnResourcesChanged; 
        
        int CollectedResources { get; }
        
        void AddResource(int amount);

        void RemoveResource(int amount);
    }
}