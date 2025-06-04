using System;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Game;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Logic.Game
{
    [DisallowMultipleComponent]
    public class DroneBehaviour : MonoBehaviour, IUnitMovement
    {
        [SerializeField, Required]
        private NavMeshAgent _agent;

        public PlayerFaction Faction { get; private set; }
        
        public Vector3 Position => transform.position;
        
        public bool DrawPath { get; }

        public void Initialize(PlayerFaction faction)
        {
            Faction = faction;
        }

        public void MoveTo(Vector3 position)
        {
            _agent.SetDestination(position);
            
            _agent.isStopped = false;
        }

        public void Stop()
        {
            _agent.isStopped = true;
        }
    }
}