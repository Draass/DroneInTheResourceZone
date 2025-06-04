using System.Collections.Generic;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Game.Providers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Logic.Game.Factions
{
    public class FactionBasePositionProvider : SerializedMonoBehaviour, IFactionBasePositionProvider
    {
        [SerializeField]
        private Dictionary<PlayerFaction, Transform> _factionPositions = new();
        
        public Vector3 GetPosition(PlayerFaction faction)
        {
            return _factionPositions[faction].position;
        }
    }
}