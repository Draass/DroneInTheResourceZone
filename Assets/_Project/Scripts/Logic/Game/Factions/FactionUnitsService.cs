using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Game.Drone;
using _Project.Scripts.Logic.Interfaces.Game.Factions;
using _Project.Scripts.Logic.Interfaces.Game.Unit;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Logic.Game.Factions
{
    public class FactionUnitsService : IFactionUnitsService
    {
        private const int MaxDronesCap = 5;
        
        private readonly IUnitFactory _unitFactory;

        public PlayerFaction PlayerFaction { get; private set; }

        public IReadOnlyDictionary<int, DroneBehaviour> Drones => _drones;
        
        public event Action OnUnitAdded;
        
        public event Action OnUnitRemoved;
        
        private Dictionary<int, DroneBehaviour> _drones = new();
        private int _nextDroneId = 1;
        
        public FactionUnitsService(IUnitFactory unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public void Initialize(PlayerFaction faction)
        {
            PlayerFaction = faction;
        }
        
        public int AddDrone()
        {
            if (_drones.Count >= MaxDronesCap)
            {
                return -1;
            }
            
            // TODO add hard cap to drone amount
            
            // give faction id as parameter
            var drone = _unitFactory.Create(PlayerFaction);
            
            // TODO spawn near faction base
            drone.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

            var droneId = _nextDroneId++;
            _drones.Add(droneId, drone);
            
            OnUnitAdded?.Invoke();

            return droneId;
        }

        public void RemoveDrone()
        {
            if (_drones.Count == 0)
            {
                return;
            }
            
            var droneEntry = _drones.First();
            var drone = droneEntry.Value;

            _drones.Remove(droneEntry.Key);
            
            Object.Destroy(drone.gameObject);
            
            OnUnitRemoved?.Invoke();
        }
    }
}
