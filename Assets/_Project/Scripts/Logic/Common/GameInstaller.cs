using System;
using _Project.Scripts.Logic.Game;
using _Project.Scripts.Logic.Game.Providers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Logic.Common
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField, Required, SceneObjectsOnly]
        private SpawnBoundsProvider _spawnBoundsProvider;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SpawnBoundsProvider>().FromInstance(_spawnBoundsProvider).AsSingle();
            
            // Resources 
            Container.BindInterfacesTo<ResourceFactory>().AsSingle();
            Container.BindInterfacesTo<ResourceSpawner>().AsSingle();
            Container.BindInterfacesTo<ResourcesSpawnTransformProvider>().AsSingle();
        }
    }
}