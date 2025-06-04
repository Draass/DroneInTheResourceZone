using _Project.Scripts.Data;
using _Project.Scripts.Logic.Game;
using UnityEngine;

namespace _Project.Scripts.Logic.Interfaces.Game.Providers
{
    public interface IFactionBasePositionProvider
    {
        public Vector3 GetPosition(PlayerFaction faction);
    }
}