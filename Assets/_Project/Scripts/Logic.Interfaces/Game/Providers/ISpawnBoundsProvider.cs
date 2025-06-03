using Unity.AI.Navigation;
using UnityEngine;

namespace _Project.Scripts.Logic.Interfaces.Game.Providers
{
    public interface ISpawnBoundsProvider
    {
        NavMeshSurface Surface {get;}
    }
}