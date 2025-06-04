using System.Collections.Generic;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Game.Factions;
using Zenject;

namespace _Project.Scripts.Logic.Game.Factions
{
    public class FactionsServicesManager : IFactionsServicesManager
    {
        private readonly IInstantiator _instantiator;
        
        private readonly Dictionary<PlayerFaction, IFactionUnitsService> _factionsServices = new();
        private readonly Dictionary<PlayerFaction, IFactionResourcesService> _factionsResourcesServices = new();
        
        public FactionsServicesManager(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public IFactionUnitsService GetUnitsService(PlayerFaction playerFaction)
        {
            return _factionsServices[playerFaction];
        }

        public IFactionResourcesService GetResourceService(PlayerFaction playerFaction)
        {
            return _factionsResourcesServices[playerFaction];
        }

        public void RegisterUnitsService(PlayerFaction playerFaction)
        {
            var factionService = _instantiator.Instantiate<FactionUnitsService>();
            
            factionService.Initialize(playerFaction);
            
            _factionsServices.TryAdd(playerFaction, factionService);
        }
        
        public void RegisterResourcesService(PlayerFaction playerFaction)
        {
            var factionResourcesService = _instantiator.Instantiate<FactionResourcesService>();
            
            _factionsResourcesServices.Add(playerFaction, factionResourcesService);
        }
    }
}