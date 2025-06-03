using System;

namespace _Project.Scripts.Logic.Interfaces.Game
{
    public interface IResourceSpawner
    {
        event Action OnResourceSpawned;

        void SpawnResource();

        void SpawnResource(string id);
    }
}