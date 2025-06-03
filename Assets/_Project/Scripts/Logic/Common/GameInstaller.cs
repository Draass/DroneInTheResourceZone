using _Project.Scripts.Logic.Game;
using _Project.Scripts.Logic.Game.Providers;
using Zenject;

namespace _Project.Scripts.Logic.Common
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Resources 
            Container.BindInterfacesTo<ResourceFactory>().AsSingle();
            Container.BindInterfacesTo<ResourceSpawner>().AsSingle();
            Container.BindInterfacesTo<ResourcesSpawnTransformProvider>().AsSingle();
        }
    }
}