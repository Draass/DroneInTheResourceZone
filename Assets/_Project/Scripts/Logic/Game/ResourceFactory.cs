using _Project.Scripts.Data;
using _Project.Scripts.Logic.Interfaces.Common;
using _Project.Scripts.Logic.Interfaces.Game;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.Infrastructure.Loaders.Abstract;
using Zenject;

namespace _Project.Scripts.Logic.Game
{
    public class ResourceFactory : IResourceFactory, IAsyncInitialize
    {
        // TODO add object pool
    
        private readonly IAssetLoader _assetLoader;
        private readonly IScopeLifetimeProvider _scopeLifetimeProvider;
        private readonly IInstantiator _instantiator;

        private ResourceItem _prefab;

        public AsyncLazy InitializeTask { get; }
    
        public ResourceFactory(
            IAssetLoader assetLoader,
            IScopeLifetimeProvider scopeLifetimeProvider,
            IInstantiator instantiator)
        {
            _assetLoader = assetLoader;
            _scopeLifetimeProvider = scopeLifetimeProvider;
            _instantiator = instantiator;

            InitializeTask = new AsyncLazy(Initialize);
        }
    
        public async UniTask Initialize()
        {
            // TODO only to test current initialize flow
            _prefab = await _assetLoader.LoadWithComponentAsync<ResourceItem>(Constants.Resources.Mineral, _scopeLifetimeProvider.ScopeLifetime);
        }

        public ResourceItem Create(string id)
        {
            return _instantiator.InstantiatePrefabForComponent<ResourceItem>(_prefab);
        }
    }
}