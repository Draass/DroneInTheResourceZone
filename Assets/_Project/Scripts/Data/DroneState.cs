namespace _Project.Scripts.Data
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