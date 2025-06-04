using _Project.Scripts.Data;

namespace _Project.Scripts.Logic.Game
{
    public interface IUnitFactory
    {
        DroneBehaviour Create(PlayerFaction faction);
    }
}