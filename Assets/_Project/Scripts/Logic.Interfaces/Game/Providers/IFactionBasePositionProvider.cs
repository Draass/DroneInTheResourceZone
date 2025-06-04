using UnityEngine;

namespace _Project.Scripts.Logic.Interfaces.Game.Providers
{
    public interface IFactionBasePositionProvider
    {
        // TODO get position for base by it's type
        public Vector3 Position { get; }
    }
}