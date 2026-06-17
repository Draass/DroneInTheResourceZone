using System;
using UnityEngine;

namespace _Project.Scripts.Logic.Interfaces.Game.Unit
{
    public interface IUnitMovement
    {
        Vector3 Position { get; }
     
        bool DrawPath { get; }
        
        void MoveTo(Vector3 position);

        void Stop();
    }

    public interface IDamageable
    {
        void TakeDamage(DamageModel damage);
    }

    public interface IHealth
    {
        event Action OnDie;
        
        public int Health { get; }
    }

    public struct DamageModel
    {
        public int Amount;
    }

    public interface IDamageDealer
    {
        void DealDamage(int id, DamageModel damage);    
    }
    
    public class UnitHealth : IHealth, IDamageable
    {
        public event Action OnDie;
        
        public int Health { get; private set; }
        
        public void TakeDamage(DamageModel damage)
        {
            Health -= damage.Amount;

            if (Health <= 0)
            {
                // TODO play some death animation
                OnDie?.Invoke();
            }
        }
    }
}