namespace _Project.Scripts.Logic.Interfaces.Ga
{
    public interface IResourceAutoSpawner
    {
        bool IsEnabled { get; set; }
        
        float SpawnRate { get; }
        
        void SetSpawnRate(float rate);
    }
}