using _Project.Scripts.Logic.Interfaces.Game.Providers;
using UnityEngine;

namespace _Project.Scripts.Logic.Game
{
    public class FactionBasePositionProvider : MonoBehaviour, IFactionBasePositionProvider
    {
        [field: SerializeField]
        public Vector3 Position { get; private set; }
    }
}