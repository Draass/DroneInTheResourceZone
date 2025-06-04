namespace _Project.Scripts.Logic.Interfaces.Game.Resource
{
    public interface IResourceAutoSpawner
    {
        bool IsEnabled { get; set; }
        
        float SpawnRate { get; }
        
        void SetSpawnRate(float rate);
    }
}