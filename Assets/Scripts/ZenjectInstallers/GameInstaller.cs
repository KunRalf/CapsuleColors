using GameLogic;
using Infrastructure;
using UnityEditor.MPE;
using UnityEngine;
using Zenject;

namespace ZenjectInstallers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EventsService>().AsSingle();
        }
    }
}