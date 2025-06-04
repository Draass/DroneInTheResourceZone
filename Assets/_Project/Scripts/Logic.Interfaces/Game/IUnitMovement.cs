using UnityEngine;

namespace _Project.Scripts.Logic.Interfaces.Game
{
    public interface IUnitMovement
    {
        Vector3 Position { get; }
        
        bool DrawPath { get; }
        
        void MoveTo(Vector3 position);

        void Stop();
    }
}