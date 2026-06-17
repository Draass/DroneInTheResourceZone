using _Project.Scripts.Logic.Interfaces.Game.Providers;
using Pathfinding;
using UnityEngine;

namespace _Project.Scripts.Logic.Game.Providers
{
    public class ResourcesSpawnTransformProvider : IResourceSpawnTransformProvider
    {
        private const int MaxAttempts = 200;
        private const float Radius = .3f;
        
        private readonly ISpawnBoundsProvider _spawnBoundsProvider;
        
        private readonly NearestNodeConstraint _walkable = NearestNodeConstraint.Walkable;

        public ResourcesSpawnTransformProvider(ISpawnBoundsProvider spawnBoundsProvider)
        {
            _spawnBoundsProvider = spawnBoundsProvider;
        }
        
        public Vector3? GetSpawnTransform()
        {
            var bounds = _spawnBoundsProvider.WorldBounds;

            for (var attempt = 0; attempt < MaxAttempts; ++attempt)
            {
                /* 1 — pick a random point inside the bounding box */
                var random = new Vector3(
                    Random.Range(bounds.min.x, bounds.max.x),
                    Random.Range(bounds.min.y, bounds.max.y),
                    Random.Range(bounds.min.z, bounds.max.z));

                var nn = AstarPath.active.GetNearest(random, _walkable);
                if (nn.node == null || !nn.node.Walkable) continue;

                var pos = (Vector3)nn.position;

                /* 3 — if the graph node lies just outside the original AABB, skip it */
                if (!bounds.Contains(pos)) continue;

                /* 4 — make sure nothing occupies the spot already */
                if (Physics.CheckSphere(pos, Radius, 3 /* layer mask */)) continue;

                /* 5 — success! */
                return pos;
            }

            Debug.LogError("ResourcesSpawnTransformProvider: failed to find a free spot.");
            return null;
        }
    }
}
