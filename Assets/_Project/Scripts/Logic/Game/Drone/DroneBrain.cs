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

        private float _collectTime = 2f;

        private IResourceItem _resource;
        
        private readonly IResourceSpawner _resourceSpawner;
        private readonly IUnitMovement _movement;
        private readonly IResourceCollectionService _collectionService;
        private readonly IFactionBasePositionProvider _positionProvider;

        public DroneBrain(
            IResourceSpawner resourceSpawner, 
            IUnitMovement movement,
            IResourceCollectionService collectionService,
            IFactionBasePositionProvider positionProvider)
        {
            _resourceSpawner = resourceSpawner;
            _movement = movement;
            _collectionService = collectionService;
            _positionProvider = positionProvider;
        }
        
        public void Tick()
        {
            // if resource is null - find resource

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
                    if (Vector3.Distance(_movement.Position, _resource.Position) < 1)
                    {
                        // Start collectiong resource
                        _state = DroneState.Collecting;
                    }
                    break;
                case DroneState.Collecting:
                    // when resource collected
                    _collectionService.CollectResource(_resource.Id);
                    _resource = null;
                    
                    var basePosition = _positionProvider.Position;
                    _movement.MoveTo(basePosition);
                    _state = DroneState.ReturnToBase;
                    
                    break;
                case DroneState.ReturnToBase:
                    // if close to base - dispose resources
                    // TODO change distance check, maybe add some animation later
                    if (Vector3.Distance(_movement.Position, _positionProvider.Position) < 4)
                    {
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