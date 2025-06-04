using _Project.Scripts.Data;

namespace _Project.Scripts.Logic.Interfaces.Game.Factions
{
    public interface IFactionsServicesManager
    {
        IFactionUnitsService GetUnitsService(PlayerFaction playerFaction);
        IFactionResourcesService GetResourceService(PlayerFaction playerFaction);

        void RegisterUnitsService(PlayerFaction playerFaction);
        void RegisterResourcesService(PlayerFaction playerFaction);
    }
}