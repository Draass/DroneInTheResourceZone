using System.Collections.Generic;
using _Project.Scripts.Data;
using _Project.Scripts.Logic.Game;
using _Project.Scripts.Logic.Interfaces.Common;
using _Project.Scripts.Logic.Interfaces.Game;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.UI.PresenterNavigationService.Abstract;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Logic.Common
{
    public class GameSceneBootstrap : MonoBehaviour
    {
        private IEnumerable<IAsyncInitialize> _initializables;
        private IResourceSpawner _resourceSpawner;
        private IPresenterNavigationService _navigationService;
        private IFactionsServicesManager _factionsServicesManager;
     
        private bool _initialized;
        
        [Inject]
        private void Construct(
            IEnumerable<IAsyncInitialize> initializables,
            IResourceSpawner resourceSpawner,
            IFactionsServicesManager factionsServicesManager
            //IPresenterNavigationService navigationService
            )
        {
            _initializables = initializables;
            _resourceSpawner = resourceSpawner;
            _factionsServicesManager = factionsServicesManager;
            //_navigationService = navigationService;
        }
        
        private void Awake()
        {
            _factionsServicesManager.RegisterUnitsService(PlayerFaction.Red);
            _factionsServicesManager.RegisterUnitsService(PlayerFaction.Blue);
            
            Initialize().Forget();
        }

        private void Start()
        {
            StartAsync().Forget();
        }

        private async UniTaskVoid StartAsync()
        {
            // await UniTask.WaitWhile<bool>(true, _ => _initializeTask.Status == UniTaskStatus.Pending);
            
            await UniTask.WaitWhile(() => !_initialized);
            
            // TODO Show game presenter
            
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