using System.Linq;
using _Project.Scripts.Logic.Interfaces.Game.Providers;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Logic.Game.Providers
{
    public class SpawnBoundsProvider : MonoBehaviour, ISpawnBoundsProvider
    {
        [SerializeField] private AstarPath _astar;

        [SerializeField] private int _graphIndex = 0;

        [Header("Fallback for graphs without explicit bounds")] [SerializeField]
        private Bounds _customBounds = new Bounds(Vector3.zero,
            new Vector3(50, 10, 50));

        public NavGraph Graph => (_astar ?? AstarPath.active).data.graphs[_graphIndex];

        public Bounds WorldBounds
        {
            get
            {
                if (Graph is GridGraph grid)
                    return GetGridGraphWorldBounds(grid);
                
                // fallback for unknown graphs
                return _customBounds;
            }
        }
        
        public Bounds GetGridGraphWorldBounds(GridGraph grid)
        {
            // Get the 8 corners of the grid in local space (centered at grid.center)
            var halfWidth  = (grid.width  * grid.nodeSize) * 0.5f;
            var halfDepth  = (grid.depth  * grid.nodeSize) * 0.5f;

            // Corners in XZ-plane, local grid space (centered at grid.center)
            Vector3[] localCorners = new Vector3[]
            {
                new Vector3(-halfWidth, 0, -halfDepth),
                new Vector3(-halfWidth, 0, +halfDepth),
                new Vector3(+halfWidth, 0, -halfDepth),
                new Vector3(+halfWidth, 0, +halfDepth),
            };

            // Transform corners to world space (rotation + position)
            var transform = grid.transform;
            var worldCorners = localCorners.Select(corner => transform.Transform(corner)).ToArray();

            // Make a Bounds from those corners
            var bounds = new Bounds(worldCorners[0], Vector3.zero);
            for (int i = 1; i < worldCorners.Length; ++i)
                bounds.Encapsulate(worldCorners[i]);
            return bounds;
        }
    }
}
