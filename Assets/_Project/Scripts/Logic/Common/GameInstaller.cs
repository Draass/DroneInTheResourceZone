using System;
using _Project.Scripts.Logic.Game;
using _Project.Scripts.Logic.Game.Providers;
using _Project.Scripts.Logic.Game.Resources;
using _Project.Scripts.Logic.Interfaces.Game;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Logic.Common
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField, Required, SceneObjectsOnly]
        private SpawnBoundsProvider _spawnBoundsProvider;

        [SerializeField, Required, SceneObjectsOnly]
        private FactionBasePositionProvider _factionBasePositionProvider;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SpawnBoundsProvider>().FromInstance(_spawnBoundsProvider).AsSingle();
            Container.BindInterfacesTo<FactionBasePositionProvider>().FromInstance(_factionBasePositionProvider).AsSingle();

            Container.BindInterfacesTo<FactionsServicesManager>().AsSingle();

            Container.BindInterfacesTo<UnitFactory>().AsSingle();
            
            // Resources 
            Container.BindInterfacesTo<ResourceCollectionService>().AsSingle();
            Container.BindInterfacesTo<ResourceFactory>().AsSingle();
            Container.BindInterfacesTo<ResourceSpawner>().AsSingle();
            Container.BindInterfacesTo<ResourcesSpawnTransformProvider>().AsSingle();
        }
    }
}