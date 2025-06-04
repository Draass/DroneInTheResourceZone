using System.Collections.Generic;
using _Project.Scripts.Logic.Interfaces.Game;
using UnityEngine;

namespace _Project.Scripts.Logic.Game.Resources
{
    public class ResourceCollectionService : IResourceCollectionService
    {
        private readonly IResourceSpawner _resourceSpawner;
        
        private readonly Dictionary<int, bool> _resourcesMap = new();

        public ResourceCollectionService(IResourceSpawner resourceSpawner)
        {
            _resourceSpawner = resourceSpawner;

            _resourceSpawner.OnResourceSpawned += OnResourceSpawned;
            _resourceSpawner.OnResourceDespawned += OnResourceDespawned;
        }

        private void OnResourceDespawned(IResourceItem obj)
        {
            _resourcesMap.Remove(obj.Id);
        }

        private void OnResourceSpawned(IResourceItem obj)
        {
            _resourcesMap.Add(obj.Id, false);
        }

        public void CollectResource(int id)
        {
            Debug.Log("Resource collected");
            _resourcesMap[id] = false;

            _resourceSpawner.Despawn(id);
        }

        public bool IsOccupied(int id)
        {
            return _resourcesMap.GetValueOrDefault(id, false);
        }

        public void SetOccupied(int id, bool value)
        {
            _resourcesMap[id] = value;
        }
    }
}