using UnityEngine;

namespace _Project.Scripts.Logic.Interfaces.Game.Providers
{
    public interface ISpawnBoundsProvider
    {
        Bounds WorldBounds  { get; } 
    }
}
