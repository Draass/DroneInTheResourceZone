using _Project.Scripts.Data;
using _Project.Scripts.Logic.Game.Drone;

namespace _Project.Scripts.Logic.Interfaces.Game.Unit
{
    public interface IUnitFactory
    {
        DroneBehaviour Create(PlayerFaction faction);
    }
}