using _Project.Scripts.Logic.Game;

namespace _Project.Scripts.Data.Interfaces.Models
{
    public interface IUnitModel
    {
        public string Id { get; }
        public PlayerFaction PlayerFaction { get; }
    }
}