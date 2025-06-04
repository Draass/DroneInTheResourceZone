using _Project.Scripts.Logic.Interfaces.Ga;
using _Project.Scripts.Logic.Interfaces.Game;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Logic.Game.Resources
{
    public class ResourceAutoSpawner : IResourceAutoSpawner, ITickable
    {
        private readonly IResourceSpawner _resourceSpawner;

        public bool IsEnabled { get; set; } = true;

        public float SpawnRate { get; private set; } = 2f;

        private float _timeFromLastSpawn;

        public ResourceAutoSpawner(IResourceSpawner resourceSpawner)
        {
            _resourceSpawner = resourceSpawner;
        }
        
        public void SetSpawnRate(float rate)
        {
            if (rate <= 0)
            {
                Debug.LogWarning("Resource spawn rate must be greater than zero");
                return;
            }
            
            SpawnRate = rate;
        }

        public void Tick()
        {
            if (!IsEnabled)
            {
                return;
            }
            
            _timeFromLastSpawn += Time.deltaTime;

            if (_timeFromLastSpawn > SpawnRate)
            {
                SpawnResource();
                
                _timeFromLastSpawn = 0f;
            }
        }

        private void SpawnResource()
        {
            _resourceSpawner.SpawnResource();
        }
    }
}