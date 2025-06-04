using System;
using System.Collections.Generic;
using _Project.Scripts.Logic.Game;

namespace _Project.Scripts.Logic.Interfaces.Game
{
    public interface IFactionUnitsService
    {
        event Action OnUnitAdded;
        event Action OnUnitRemoved;
        
        IReadOnlyDictionary<int, DroneBehaviour> Drones { get; }
        
        int AddDrone();
        
        void RemoveDrone();
    }
}