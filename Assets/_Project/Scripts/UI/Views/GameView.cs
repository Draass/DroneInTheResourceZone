using System;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Game;
using _Project.Scripts.Logic.Interfaces.Game;
using DraasGames.Core.Runtime.UI.Views.Concrete;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.Views
{
    public class GameView : View
    {
        [SerializeField] 
        private Button _spawnResourceButton;
        
        [SerializeField, BoxGroup("Red")]
        private Button _addDroneButtonRed;
        
        [SerializeField, BoxGroup("Blue")]
        private Button _addDroneButtonBlue;
        
        [SerializeField, BoxGroup("Red")]
        private Button _removeDroneButtonRed;
        
        [SerializeField, BoxGroup("Blue")]
        private Button _removeDroneButtonBlue;

        [SerializeField] 
        private Slider _droneAmountSlider;
        
        private IResourceSpawner _resourceSpawner;
        private IFactionsServicesManager _factionsServicesManager;

        [Inject]
        private void Construct(
            IResourceSpawner resourceSpawner,
            IFactionsServicesManager factionsServicesManager)
        {
            _resourceSpawner = resourceSpawner;
            _factionsServicesManager = factionsServicesManager;
        }
        
        protected override void Awake()
        {
            base.Awake();
            
            _spawnResourceButton.onClick.AddListener(SpawnResoource);
            //_droneAmountSlider.onValueChanged.AddListener(OnSliderValueChanged);
            
            _addDroneButtonRed.onClick.AddListener(() => AddDrone(PlayerFaction.Red));
            _addDroneButtonBlue.onClick.AddListener(() => AddDrone(PlayerFaction.Blue));
            
            _removeDroneButtonBlue.onClick.AddListener(() => RemoveDrone(PlayerFaction.Blue));
            _removeDroneButtonRed.onClick.AddListener(() => RemoveDrone(PlayerFaction.Red));
        }

        private void AddDrone(PlayerFaction faction)
        {
            var unitsService = _factionsServicesManager.GetUnitsService(faction);

            unitsService.AddDrone();
        }
        
        private void RemoveDrone(PlayerFaction faction)
        {
            var unitsService = _factionsServicesManager.GetUnitsService(faction);

            unitsService.RemoveDrone();
        }

        private void OnSliderValueChanged(float value)
        {
            // var currentDroneAmount = _factionUnitsService.Drones.Count;
            //
            // // TODO check if more or less
            //
            // _factionUnitsService.AddDrone();
        }

        private void SpawnResoource()
        {
            _resourceSpawner.SpawnResource();
        }
    }
}