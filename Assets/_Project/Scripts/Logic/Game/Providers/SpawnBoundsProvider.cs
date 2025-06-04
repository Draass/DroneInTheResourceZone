using _Project.Scripts.Logic.Interfaces.Game.Providers;
using Sirenix.OdinInspector;
using Unity.AI.Navigation;
using UnityEngine;

namespace _Project.Scripts.Logic.Game.Providers
{
    public class SpawnBoundsProvider : MonoBehaviour, ISpawnBoundsProvider
    {
        [SerializeField, Required, SceneObjectsOnly]
        private NavMeshSurface _surface;
        
        public NavMeshSurface Surface => _surface;
    }
}