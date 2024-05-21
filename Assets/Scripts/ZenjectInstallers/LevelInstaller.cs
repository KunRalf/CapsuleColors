using GameLogic;
using Infrastructure;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace ZenjectInstallers
{
    public class LevelInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_levelPoints")] [SerializeField] private LevelStartPositions levelStartPositions;
  
        
        public override void InstallBindings()
        {
            Container.Bind<LevelStartPositions>().FromInstance(levelStartPositions).AsSingle().NonLazy();
            Container.Bind<LevelInitiator>().AsSingle().NonLazy();
        }
    }
}