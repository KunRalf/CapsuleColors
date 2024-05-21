using GameLogic.Platforms;
using GameLogic.Station;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class LevelInitiator 
    {
        private LevelStartPositions _levelStartPositions;
        private readonly IPlatformFactory _platformFactory;
        private readonly IStationFactory _stationFactory;

        public LevelInitiator(LevelStartPositions startPositions, 
            IPlatformFactory platformFactory, IStationFactory stationFactory)
        {
            _levelStartPositions = startPositions;
            _platformFactory = platformFactory;
            _stationFactory = stationFactory;
            Init();
        }

        private async void Init()
        {
            var platform = await _platformFactory.Create(_levelStartPositions.PlatformStartPos, _levelStartPositions.PlatformStartRot);
            var stantion = await _stationFactory.Create(
                _levelStartPositions.StantionStartPos, _levelStartPositions.StantionStartRot);
            platform.GetComponent<PlatformMover>().MoveToPoint(stantion.transform,stantion.GetComponent<StationController>());
            stantion.GetComponent<StationController>().Init();
            stantion.GetComponent<StationController>().EnableNavMesh(true);
        }
    }
}