namespace _Project.Scripts.Logic.Interfaces.Common
{
    public interface IFactory<out T>
    {
        T Create(string id);
    }
}