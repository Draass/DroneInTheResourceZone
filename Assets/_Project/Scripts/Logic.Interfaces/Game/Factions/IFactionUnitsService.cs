using System;
using System.Collections.Generic;
using _Project.Scripts.Logic.Game.Drone;

namespace _Project.Scripts.Logic.Interfaces.Game.Factions
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