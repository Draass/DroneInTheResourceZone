namespace _Project.Scripts.Logic.Data
{
    public enum DroneState
    {
        None = 0, 
        SeekResource,
        MoveToResource,
        Collecting,
        ReturnToBase,
        Disposing 
    }
}