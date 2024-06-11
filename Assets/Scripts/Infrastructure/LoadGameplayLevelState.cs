using GameLogic;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LoadGameplayLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public LoadGameplayLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private async void OnLoaded()
        {
            await _uiFactory.CreateUIRoot();
            await _uiFactory.CreateHUD();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }
    }
}