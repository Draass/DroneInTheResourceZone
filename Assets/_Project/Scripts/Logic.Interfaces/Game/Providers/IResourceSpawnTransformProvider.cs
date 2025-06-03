using UnityEngine;

namespace _Project.Scripts.Logic.Interfaces.Game.Providers
{
    public interface IResourceSpawnTransformProvider
    {
        Vector3? GetSpawnTransform();
    }
}