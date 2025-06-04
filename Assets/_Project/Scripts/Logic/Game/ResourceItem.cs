using UnityEngine;

namespace _Project.Scripts.Logic.Game
{
    public interface IResourceItem
    {
        int Id { get; }
        Vector3 Position { get; }
    }
    
    [DisallowMultipleComponent]
    public class ResourceItem : MonoBehaviour, IResourceItem
    {
        public int Id => GetInstanceID();
        
        public Vector3 Position => transform.position;
    }
}