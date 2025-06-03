using UnityEngine;

namespace _Project.Scripts.Logic.Interfaces.Game.Providers
{
    public interface ISpawnBoundsProvider
    {
        Transform LeftBound { get; }
        Transform RightBound { get; }
    }
}