using System;
using System.Collections.Generic;
using _Project.Scripts.Logic.Interfaces.Game;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Logic.Game
{
    public interface IUnitMovement
    {
        Vector3 Position { get; }
        
        bool DrawPath { get; }
        
        void MoveTo(Vector3 position);

        void Stop();
    }

    public interface IFactionBasePositionProvider
    {
        // TODO get position for base by it's type
        public Vector3 Position { get; }
    }

    public enum DroneState
    {
        None = 0, 
        SeekResource,
        MoveToResource,
        Collecting,
        ReturnToBase,
        Disposing 
    }

    public interface IResourceCollectionService
    {
        void CollectResource(int id);
        
        bool IsOccupied(int id);
        
        void SetOccupied(int id, bool value);
    }

    public class ResourceCollectionService : IResourceCollectionService
    {
        private readonly IResourceSpawner _resourceSpawner;
        
        private readonly Dictionary<int, bool> _resourcesMap = new();

        public ResourceCollectionService(IResourceSpawner resourceSpawner)
        {
            _resourceSpawner = resourceSpawner;

            _resourceSpawner.OnResourceSpawned += OnResourceSpawned;
        }

        private void OnResourceSpawned(IResourceItem obj)
        {
            _resourcesMap.Add(obj.Id, false);
        }

        public void CollectResource(int id)
        {
            Debug.Log("Resource collected");
            _resourcesMap[id] = false;
        }

        public bool IsOccupied(int id)
        {
            return _resourcesMap.GetValueOrDefault(id, true);
        }

        public void SetOccupied(int id, bool value)
        {
            _resourcesMap[id] = value;
        }
    }
    
    [DisallowMultipleComponent]
    public class DroneBehaviour : MonoBehaviour, IUnitMovement
    {
        [SerializeField, Required]
        private NavMeshAgent _agent;

        public Vector3 Position => transform.position;
        
        public bool DrawPath { get; }

        public void MoveTo(Vector3 position)
        {
            _agent.SetDestination(position);
            
            _agent.isStopped = false;
        }

        public void Stop()
        {
            _agent.isStopped = true;
        }
    }
}