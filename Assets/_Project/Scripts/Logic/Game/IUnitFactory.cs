using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Common;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.Infrastructure.Loaders.Abstract;
using Zenject;

namespace _Project.Scripts.Logic.Game
{
    public interface IUnitFactory
    {
        DroneBehaviour Create(PlayerFaction faction);
    }

    public class UnitFactory : IUnitFactory, IAsyncInitialize
    {
        private const string DroneKey = "Drone";
        
        private readonly IInstantiator _instantiator;
        private readonly IAssetLoader _assetLoader;
        private readonly IScopeLifetimeProvider _lifetimeProvider;
        
        public AsyncLazy InitializeTask { get; }

        private DroneBehaviour _prefab;

        public UnitFactory(
            IInstantiator instantiator, 
            IAssetLoader assetLoader, 
            IScopeLifetimeProvider lifetimeProvider)
        {
            _instantiator = instantiator;
            _assetLoader = assetLoader;
            _lifetimeProvider = lifetimeProvider;

            InitializeTask = new AsyncLazy(InitializeAsync);
        }

        private async UniTask InitializeAsync()
        {
            _prefab = await _assetLoader
                .LoadWithComponentAsync<DroneBehaviour>(DroneKey, _lifetimeProvider.ScopeLifetime);
        }
        
        public DroneBehaviour Create(PlayerFaction faction)
        {
            var unit = _instantiator.InstantiatePrefabForComponent<DroneBehaviour>(_prefab);
            
            unit.Initialize(faction);
            
            return unit;
        }
    }
}