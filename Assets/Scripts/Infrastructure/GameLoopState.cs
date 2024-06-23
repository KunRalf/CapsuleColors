using GameLogic;
using Infrastructure.Factories.Interfaces;
using UnityEngine;

namespace Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly ICapsuleFactory _capsuleFactory;
        private readonly IPlatformFactory _platformFactory;
        private readonly IStationFactory _stationFactory;
        private readonly IUIFactory _uiFactory;

        public GameLoopState(ICapsuleFactory capsuleFactory, 
            IPlatformFactory platformFactory, 
            IStationFactory stationFactory, IUIFactory uiFactory)
        {
            _capsuleFactory = capsuleFactory;
            _platformFactory = platformFactory;
            _stationFactory = stationFactory;
            _uiFactory = uiFactory;
        }

        public void Exit()
        {
         //   _capsuleFactory.CleanUp();
            _platformFactory.CleanUp();
            _stationFactory.CleanUp();
            _uiFactory.CleanUp();
        }

        public void Enter()
        {
            Debug.Log("GameLoop");
        }
    }
}