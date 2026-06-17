using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Game.Unit;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Logic.Game.Drone
{
    [DisallowMultipleComponent]
    public class DroneBehaviour : MonoBehaviour, IUnitMovement
    {
        [SerializeField, Required] 
        private AIPath _astarAI; 

        public PlayerFaction Faction { get; private set; }
        
        public Vector3 Position => transform.position;
        
        public bool DrawPath { get; }

        public void Initialize(PlayerFaction faction)
        {
            Faction = faction;
        }

        public void MoveTo(Vector3 position)
        {
            _astarAI.destination = position;
            _astarAI.isStopped = false;
        }

        public void Stop()
        {
            _astarAI.isStopped = true;
        }
    }
}
