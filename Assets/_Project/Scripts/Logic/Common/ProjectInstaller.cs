using _Project.Scripts.Data;
using Zenject;

namespace _Project.Scripts.Logic.Common
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<GameEntitites>()
                .AsSingle();
        }
    }
}