using Cinemachine;
using GameLogic.Interfaces;
using GameLogic.Platforms;
using GameLogic.Station;
using Infrastructure;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class LevelInitiator 
    {
        private LevelStartPositions _levelStartPositions;
        private readonly CinemachineVirtualCamera _camera;
        private readonly IPlatformFactory _platformFactory;
        private readonly IStationGenerate _stationGenerate;


        public LevelInitiator(LevelStartPositions startPositions, CinemachineVirtualCamera camera,
            IPlatformFactory platformFactory, IStationGenerate stationGenerate)
        {
            _levelStartPositions = startPositions;
            _camera = camera;
            _platformFactory = platformFactory;
            _stationGenerate = stationGenerate;
            InitLevel();
        }

        private async void InitLevel()
        {
            var platform = await _platformFactory.Create(_levelStartPositions);
            await _stationGenerate.GenerateStation(0);
            _camera.Follow = platform.transform;
            _camera.LookAt = platform.transform;
            platform.SetNextPoint(_stationGenerate.FirstStation);
        }

    }
}