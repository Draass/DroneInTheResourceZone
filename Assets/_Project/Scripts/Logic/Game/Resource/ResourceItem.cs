using UnityEngine;

namespace _Project.Scripts.Logic.Game.Resource
{
    public interface IResourceItem
    {
        int Id { get; }
        Vector3 Position { get; }
    }
    
    [DisallowMultipleComponent]
    public class ResourceItem : MonoBehaviour, IResourceItem
    {
        public int Id { get; private set; }
        
        public Vector3 Position => transform.position;

        public void Initialize(int id)
        {
            Id = id;
        }
    }
}
