using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Game.Factions;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.Elements
{
    public class UnitsCounter : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _counter;
        
        [SerializeField] 
        private PlayerFaction _playerFaction;
        
        private IFactionsServicesManager _factionsServicesManager;
        
        private IFactionUnitsService _factionUnitsService;

        [Inject]
        private void Construct(IFactionsServicesManager servicesManager)
        {
            _factionsServicesManager = servicesManager;
        }

        void Start()
        {
            _factionUnitsService = _factionsServicesManager.GetUnitsService(_playerFaction);
            
            _factionUnitsService.OnUnitAdded += OnUnitChanged;
            _factionUnitsService.OnUnitRemoved += OnUnitChanged;
        }
        
        private void OnDestroy()
        {
            _factionUnitsService.OnUnitAdded -= OnUnitChanged;
            _factionUnitsService.OnUnitRemoved -= OnUnitChanged;
        }
        
        private void OnUnitChanged()
        {
            var count = _factionUnitsService.Drones.Count;
            
            _counter.SetText(count.ToString());
        }
    }
}