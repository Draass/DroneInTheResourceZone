using _Project.Scripts.Logic.Interfaces.Game.Providers;
using UnityEngine;

namespace _Project.Scripts.Logic.Game.Providers
{
    public class ResourcesSpawnTransformProvider : IResourceSpawnTransformProvider
    {
        private readonly ISpawnBoundsProvider _spawnBoundsProvider;
        
        public Transform GetSpawnTransform()
        {
            // TODO get spawn bounds
            
            // get random point inside bounds
            
            // check if occupied
            
            // if not occupied - return transform
            
            // if occupied - retry

            return null;
        }
    }
}