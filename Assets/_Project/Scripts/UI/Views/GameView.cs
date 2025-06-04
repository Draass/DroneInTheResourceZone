using _Project.Scripts.Logic.Interfaces.Game;
using DraasGames.Core.Runtime.UI.Views.Concrete;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI.Views
{
    public class GameView : View
    {
        [SerializeField] 
        private Button _spawnResourceButton;

        private IResourceSpawner _resourceSpawner;

        [Inject]
        private void Construct(IResourceSpawner resourceSpawner)
        {
            _resourceSpawner = resourceSpawner;
        }
        
        protected override void Awake()
        {
            base.Awake();
            
            _spawnResourceButton.onClick.AddListener(SpawnResoource);
        }

        private void SpawnResoource()
        {
            _resourceSpawner.SpawnResource();
        }
    }
}