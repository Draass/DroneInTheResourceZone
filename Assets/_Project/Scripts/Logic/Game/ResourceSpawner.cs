using System;
using System.Collections.Generic;
using _Project.Scripts.Data.Interfaces;
using _Project.Scripts.Logic.Interfaces.Game;
using _Project.Scripts.Logic.Interfaces.Game.Providers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Logic.Game
{
    public class ResourceSpawner : IResourceSpawner
    {
        private readonly IResourceSpawnTransformProvider _resourceSpawnTransformProvider;
        private readonly IGameEntitites _gameEntities;
        private readonly IResourceFactory _resourceFactory;

        public IReadOnlyList<IResourceItem> ResourceItems => _resourceItems;
        
        private List<IResourceItem> _resourceItems = new List<IResourceItem>();
        
        public event Action<IResourceItem> OnResourceSpawned;
    
        // TODO should be in other place
        public bool IsEnabled { get; private set; }
    
        public int SpawnRate { get; private set; }

        public ResourceSpawner(
            IResourceSpawnTransformProvider resourceSpawnTransformProvider,
            IGameEntitites gameEntities,
            IResourceFactory resourceFactory)
        {
            _gameEntities = gameEntities;
            _resourceSpawnTransformProvider = resourceSpawnTransformProvider;
            _resourceFactory = resourceFactory;
        }
    
        public void SpawnResource()
        {
            // Get random resource
            var resourceId = GetRandomResource();
        
            var item = CreateItemForId(resourceId);
            
            _resourceItems.Add(item);

            // TODO add to event parameters
            OnResourceSpawned?.Invoke(item);
        }
    
        public void SpawnResource(string id)
        {
            var item = CreateItemForId(id);
        
            _resourceItems.Add(item);
            
            OnResourceSpawned?.Invoke(item);
        }
    
        private ResourceItem CreateItemForId(string resourceId)
        {
            var resourceItem = _resourceFactory.Create(resourceId);

            var resourcePosition = _resourceSpawnTransformProvider.GetSpawnTransform();
            
            resourceItem.transform.SetPositionAndRotation(resourcePosition.Value, Quaternion.identity);

            return resourceItem;
        }
        
        private string GetRandomResource()
        {
            var randomResourceIndex = Random.Range(0, _gameEntities.ResourceModels.Count);
        
            return _gameEntities.ResourceModels[randomResourceIndex].Id;
        }
    }
}