﻿using Cinemachine;
using GameLogic;
using Infrastructure;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace ZenjectInstallers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelStartPositions _levelStartPositions;
        [SerializeField] private CinemachineVirtualCamera _camera;
        
        public override void InstallBindings()
        {
            Container.Bind<LevelStartPositions>().FromInstance(_levelStartPositions).AsSingle().NonLazy();
            Container.Bind<CinemachineVirtualCamera>().FromInstance(_camera).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StationGenerator>().AsSingle();
            Container.Bind<LevelInitiator>().AsSingle().NonLazy();
        }
    }
}