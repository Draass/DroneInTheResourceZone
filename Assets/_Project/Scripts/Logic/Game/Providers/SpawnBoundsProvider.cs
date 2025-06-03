using _Project.Scripts.Logic.Interfaces.Game.Providers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Logic.Game.Providers
{
    public class SpawnBoundsProvider : MonoBehaviour, ISpawnBoundsProvider
    {
        [field: SerializeField, Required, SceneObjectsOnly]
        public Transform LeftBound { get; private set; }
        
        [field: SerializeField, Required, SceneObjectsOnly]
        public Transform RightBound { get; private set; }
    }
}