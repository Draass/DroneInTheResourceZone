using System;
using _Project.Scripts.Logic.Game;

namespace _Project.Scripts.Logic.Interfaces.Game
{
    public interface IFactionResourcesService
    {
        event Action<int> OnResourcesChanged; 
        
        int CollectedResources { get; }
        
        void AddResource(int amount);

        void RemoveResource(int amount);
    }
}