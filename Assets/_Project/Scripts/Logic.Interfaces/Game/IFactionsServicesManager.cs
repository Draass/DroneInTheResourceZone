using System.Collections.Generic;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Game;
using Zenject;

namespace _Project.Scripts.Logic.Interfaces.Game
{
    public interface IFactionsServicesManager
    {
        IFactionUnitsService GetUnitsService(PlayerFaction playerFaction);
        IFactionService GetResourceService(PlayerFaction playerFaction);

        void RegisterUnitsService(PlayerFaction playerFaction);
    }

    public class FactionsServicesManager : IFactionsServicesManager
    {
        private readonly IInstantiator _instantiator;
        
        private Dictionary<PlayerFaction, IFactionUnitsService> _factionsServices = new();
        
        public FactionsServicesManager(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public IFactionUnitsService GetUnitsService(PlayerFaction playerFaction)
        {
            return _factionsServices[playerFaction];
        }

        public IFactionService GetResourceService(PlayerFaction playerFaction)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterUnitsService(PlayerFaction playerFaction)
        {
            var factionService = _instantiator.Instantiate<FactionUnitsService>();
            
            factionService.Initialize(playerFaction);
            
            _factionsServices.TryAdd(playerFaction, factionService);
        }
    }
}