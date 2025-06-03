using _Project.Scripts.Logic.Interfaces.Game.Providers;
using DraasGames.Core.Runtime.Infrastructure.Logger;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Logic.Game.Providers
{
    public class ResourcesSpawnTransformProvider : IResourceSpawnTransformProvider
    {
        private const int MaxAttempts = 25;
        private const int Radius = 1;
        
        private readonly ISpawnBoundsProvider _spawnBoundsProvider;

        public ResourcesSpawnTransformProvider(ISpawnBoundsProvider spawnBoundsProvider)
        {
            _spawnBoundsProvider = spawnBoundsProvider;
        }
        
        public Vector3? GetSpawnTransform()
        {
            var bounds = _spawnBoundsProvider.Surface.navMeshData.sourceBounds;
            var surface = _spawnBoundsProvider.Surface;
            
            Vector3 centerW = surface.transform.TransformPoint(bounds.center);
            Vector3 extW = Vector3.Scale(bounds.extents, surface.transform.lossyScale);

            Vector3 minW = centerW - extW;
            Vector3 maxW = centerW + extW;

            for (int attempt = 0; attempt < MaxAttempts; attempt++)
            {
                var random = new Vector3(
                    Random.Range(minW.x, maxW.x),
                    Random.Range(minW.y, maxW.y),
                    Random.Range(minW.z, maxW.z));

                if (!NavMesh.SamplePosition(random, out var hit, 1f, NavMesh.AllAreas))
                {
                    continue;
                }
                
                Vector3 pos = hit.position;

                var isOccupied = Physics.CheckSphere(pos, Radius, 3);

                if (!isOccupied)
                {
                    return pos;
                }
            }

            Debug.LogError("Could not get spawn bounds");

            return null;
        }
    }
}