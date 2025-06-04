using _Project.Scripts.Logic.Game.Drone;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Logic.Game
{
    public class DroneInstaller : MonoInstaller
    {
        [SerializeField, Required] 
        private DroneBehaviour _droneBehaviour;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DroneBehaviour>().FromInstance(_droneBehaviour).AsSingle();
            
            Container.BindInterfacesTo<DroneBrain>().AsSingle();
        }
    }
}