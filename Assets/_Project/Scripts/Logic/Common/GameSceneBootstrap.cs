using System.Collections.Generic;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Common;
using _Project.Scripts.Logic.Interfaces.Game.Factions;
using _Project.Scripts.Logic.Interfaces.Game.Resource;
using _Project.Scripts.UI.Views;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.UI.Views.Abstract;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Logic.Common
{
    public class GameSceneBootstrap : MonoBehaviour
    {
        private IEnumerable<IAsyncInitialize> _initializables;
        private IResourceSpawner _resourceSpawner;
        private IFactionsServicesManager _factionsServicesManager;
     
        private bool _initialized;
        
        [Inject]
        private void Construct(
            IEnumerable<IAsyncInitialize> initializables,
            IResourceSpawner resourceSpawner,
            IFactionsServicesManager factionsServicesManager
            )
        {
            _initializables = initializables;
            _resourceSpawner = resourceSpawner;
            _factionsServicesManager = factionsServicesManager;
        }
        
        private void Awake()
        {
            _factionsServicesManager.RegisterUnitsService(PlayerFaction.Red);
            _factionsServicesManager.RegisterUnitsService(PlayerFaction.Blue);
            
            _factionsServicesManager.RegisterResourcesService(PlayerFaction.Red);
            _factionsServicesManager.RegisterResourcesService(PlayerFaction.Blue);
            
            Initialize().Forget();
        }

        private void Start()
        {
            StartAsync().Forget();
        }

        private async UniTaskVoid StartAsync()
        {
            await UniTask.WaitWhile(() => !_initialized);
            
            _resourceSpawner.SpawnResource();
        }
        
        private async UniTask Initialize()
        {
            foreach (var initializable in _initializables)
            {
                await initializable.InitializeTask;
            }

            _initialized = true;
        }
    }
}