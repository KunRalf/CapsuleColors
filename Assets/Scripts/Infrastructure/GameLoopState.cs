using Infrastructure.Factories.Interfaces;
using UnityEngine;

namespace Infrastructure
{
    public class GameLoopState : IState
    {
        private readonly ICapsuleFactory _capsuleFactory;
        private readonly IPlatformFactory _platformFactory;
        private readonly IStationFactory _stationFactory;

        public GameLoopState(ICapsuleFactory capsuleFactory, IPlatformFactory platformFactory, IStationFactory stationFactory)
        {
            _capsuleFactory = capsuleFactory;
            _platformFactory = platformFactory;
            _stationFactory = stationFactory;
        }

        public void Exit()
        {
            _capsuleFactory.CleanUp();
            _platformFactory.CleanUp();
            _stationFactory.CleanUp();
        }

        public void Enter()
        {
            Debug.Log("GameLoop");
        }
    }
}