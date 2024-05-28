using Infrastructure;
using Infrastructure.Factories;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class InfrastructureInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private GameBootstrapper _game;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameBootstrapper>().FromInstance(_game).AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            
            BindFactories();
        }

        private void BindFactories()
        {
            Container.Bind<IPlatformFactory>().To<PlatformFactory>().AsSingle();
            Container.Bind<IStationFactory>().To<StationFactory>().AsSingle();
            Container.Bind<ICapsuleFactory>().To<CapsuleFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }
    }
}