using System;
using _Project.Scripts.Data.Interfaces;
using _Project.Scripts.Logic.Interfaces.Game;
using _Project.Scripts.Logic.Interfaces.Game.Providers;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Logic.Game
{
    public class ResourceSpawner : IResourceSpawner
    {
        private readonly IResourceSpawnTransformProvider _resourceSpawnTransformProvider;
        private readonly IGameEntitites _gameEntities;
        private readonly IResourceFactory _resourceFactory;

        public event Action OnResourceSpawned;
    
        // TODO should be in other place
        public bool IsEnabled { get; private set; }
    
        public int SpawnRate { get; private set; }

        public ResourceSpawner(
            IResourceSpawnTransformProvider resourceSpawnTransformProvider,
            IGameEntitites gameEntities,
            IResourceFactory resourceFactory)
        {
            _resourceSpawnTransformProvider = resourceSpawnTransformProvider;
            _resourceFactory = resourceFactory;
        }
    
        public void SpawnResource()
        {
            // Get random resource
            var resourceId = GetRandomResource();
        
            CreateItemForId(resourceId);

            // TODO add to event parameters
            OnResourceSpawned?.Invoke();
        }
    
        public void SpawnResource(string id)
        {
            CreateItemForId(id);
        
            OnResourceSpawned?.Invoke();
        }
    
        private ResourceItem CreateItemForId(string resourceId)
        {
            var resourceItem = _resourceFactory.Create(resourceId);

            var resourceTransform = _resourceSpawnTransformProvider.GetSpawnTransform();
        
            resourceItem.transform.SetParent(resourceTransform);

            return resourceItem;
        }


        private string GetRandomResource()
        {
            var randomResourceIndex = Random.Range(0, _gameEntities.ResourceModels.Count);
        
            return _gameEntities.ResourceModels[randomResourceIndex].Id;
        }
    }
}