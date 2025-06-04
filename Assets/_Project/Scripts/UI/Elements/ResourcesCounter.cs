using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Game.Factions;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI.Elements
{
    public class ResourcesCounter : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _counter;
        
        [SerializeField] 
        private PlayerFaction _playerFaction;
        
        private IFactionsServicesManager _factionsServicesManager;
        
        private IFactionResourcesService _factionResourcesService;

        [Inject]
        private void Construct(IFactionsServicesManager servicesManager)
        {
            _factionsServicesManager = servicesManager;
        }

        void Start()
        {
            _factionResourcesService = _factionsServicesManager.GetResourceService(_playerFaction);
            
            _factionResourcesService.OnResourcesChanged += OnResourcesChanged;
        }

        private void OnDestroy()
        {
            _factionResourcesService.OnResourcesChanged -= OnResourcesChanged;
        }
        
        private void OnResourcesChanged(int obj)
        {
            _counter.SetText(obj.ToString());
        }
    }
}