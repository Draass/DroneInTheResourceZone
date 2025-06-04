using System;
using System.Collections.Generic;
using _Project.Scripts.Logic.Game;

namespace _Project.Scripts.Logic.Interfaces.Game
{
    public interface IResourceSpawner
    {
        IReadOnlyList<IResourceItem> ResourceItems { get; }
        
        event Action<IResourceItem> OnResourceSpawned;
        event Action<IResourceItem> OnResourceDespawned;

        void SpawnResource();

        void SpawnResource(string id);
        void Despawn(int id);
    }
}