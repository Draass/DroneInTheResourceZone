using System;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Game;
using _Project.Scripts.Logic.Game.Resources;
using _Project.Scripts.Logic.Interfaces.Ga;
using _Project.Scripts.Logic.Interfaces.Game;
using DraasGames.Core.Runtime.UI.Views.Concrete;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.Views
{
    public class GameView : View
    {
        [SerializeField, BoxGroup("General")] 
        private Button _spawnResourceButton;

        [SerializeField, BoxGroup("General")] 
        private TMP_InputField _spawnRateInputField;
        
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
        private IResourceAutoSpawner _resourceAutoSpawner;
        private IFactionsServicesManager _factionsServicesManager;

        [Inject]
        private void Construct(
            IResourceSpawner resourceSpawner,
            IFactionsServicesManager factionsServicesManager,
            IResourceAutoSpawner resourceAutoSpawner)
        {
            _resourceSpawner = resourceSpawner;
            _factionsServicesManager = factionsServicesManager;
            _resourceAutoSpawner = resourceAutoSpawner;
        }
        
        protected override void Awake()
        {
            base.Awake();
            
            _spawnResourceButton.onClick.AddListener(SpawnResoource);
            _spawnRateInputField.onEndEdit.AddListener(OnSpawnRateChanged);
            //_droneAmountSlider.onValueChanged.AddListener(OnSliderValueChanged);
            
            _addDroneButtonRed.onClick.AddListener(() => AddDrone(PlayerFaction.Red));
            _addDroneButtonBlue.onClick.AddListener(() => AddDrone(PlayerFaction.Blue));
            
            _removeDroneButtonBlue.onClick.AddListener(() => RemoveDrone(PlayerFaction.Blue));
            _removeDroneButtonRed.onClick.AddListener(() => RemoveDrone(PlayerFaction.Red));
        }

        private void Start()
        {
            _spawnRateInputField.SetTextWithoutNotify(_resourceAutoSpawner.SpawnRate.ToString());
        }

        private void OnSpawnRateChanged(string arg0)
        {
            float.TryParse(arg0, out var spawnRate);

            if (spawnRate > 0)
            {
                _resourceAutoSpawner.SetSpawnRate(spawnRate);
            }
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