using System;
using _Project.Scripts.Logic.Data;
using _Project.Scripts.Logic.Interfaces.Game;
using _Project.Scripts.Logic.Interfaces.Game.Providers;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Logic.Game.Drone
{
    public class DroneBrain :  ITickable
    {
        private DroneState _state = DroneState.None;

        private const int DistanceToPickResource = 2;
        private const int DistanceToDisposeResource = 4;

        private float _collectTime = 2f;

        private IResourceItem _resource;
        
        private readonly IResourceSpawner _resourceSpawner;
        private readonly IUnitMovement _movement;
        private readonly IResourceCollectionService _collectionService;
        private readonly IFactionBasePositionProvider _positionProvider;
        private readonly IFactionsServicesManager _factionsServicesManager;
        
        private readonly DroneBehaviour _droneBehaviour;
        
        private IFactionResourcesService _factionResourcesService;

        public DroneBrain(
            IResourceSpawner resourceSpawner, 
            IUnitMovement movement,
            IResourceCollectionService collectionService,
            IFactionBasePositionProvider positionProvider,
            DroneBehaviour droneBehaviour,
            IFactionsServicesManager factionsServicesManager)
        {
            _resourceSpawner = resourceSpawner;
            _movement = movement;
            _collectionService = collectionService;
            _positionProvider = positionProvider;
            _droneBehaviour = droneBehaviour;
            _factionsServicesManager = factionsServicesManager;
        }
        
        public void Tick()
        {
            switch (_state)
            {
                case DroneState.None:
                    _state = DroneState.SeekResource;
                    break;
                case DroneState.SeekResource:
                    FindClosestResource();

                    if (_resource != null)
                    {
                        _collectionService.SetOccupied(_resource.Id, true);
                        
                        _movement.MoveTo(_resource.Position);
                        
                        _state = DroneState.MoveToResource;
                    }
                    break;
                case DroneState.MoveToResource:
                    if (Vector3.Distance(_movement.Position, _resource.Position) < DistanceToPickResource)
                    {
                        // Start collectiong resource
                        _state = DroneState.Collecting;
                    }
                    break;
                case DroneState.Collecting:
                    // when resource collected
                    _collectionService.CollectResource(_resource.Id);
                    _resource = null;
                    
                    var basePosition = _positionProvider.GetPosition(_droneBehaviour.Faction);
                    _movement.MoveTo(basePosition);
                    _state = DroneState.ReturnToBase;
                    
                    break;
                case DroneState.ReturnToBase:
                    // TODO walkaround, drone behavior is initialized later that Initialize is called here
                    // there should be no drone behaviour at all, other id source
                    _factionResourcesService ??= _factionsServicesManager.GetResourceService(_droneBehaviour.Faction);
              
                    if (Vector3.Distance(_movement.Position, _positionProvider.GetPosition(_droneBehaviour.Faction)) < DistanceToDisposeResource)
                    {
                        _factionResourcesService.AddResource(1);
                        
                        _state = DroneState.SeekResource;
                    }
                    break;
                // case DroneState.Disposing:
                //     _state = DroneState.SeekResource;
                //     break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void FindClosestResource()
        {
            IResourceItem resourceItem = null;
            
            foreach (var item in _resourceSpawner.ResourceItems)
            {
                if (!_collectionService.IsOccupied(item.Id))
                {
                    resourceItem = item;
                    break;
                }
            }
            
            if (resourceItem == null)
            {
                Debug.Log("Could not find available resource");
                // everything is occupied for now, wait
                return;
            }
            
            _resource = resourceItem;
        }
    }
}