using GameLogic.DataObjects;
using GameLogic.Interfaces;
using GameLogic.Platforms;
using GameLogic.Station.Interfaces;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class LevelLogic : ILevelLogic
    {
        private readonly IStationGenerate _stationGenerate;
        private readonly IPlatformFactory _platformFactory;

        private readonly LevelInitiator _levelInitiator;

        //   private readonly PlatformController _mainPlatform;
        private readonly GameData _gameData;
        public int CurrentStationId { get; private set; }
        private int _platformsBeforeGenerate = 2;
        
        public LevelLogic(IStationGenerate stationGenerate, IPlatformFactory platformFactory)
        {
            _stationGenerate = stationGenerate;
            _platformFactory = platformFactory;
            // _mainPlatform = platformFactory.PlatformController;
            //TODO: сюда подтянуть сейвер
            _gameData = new GameData(10,0);
        }

        public void TimeIsOver()
        {
            CurrentStationId = _platformFactory.PlatformController.CurrentStationId;
            _platformFactory.PlatformController.SetNextPoint(_stationGenerate.GetStationById(CurrentStationId + 1));
            _stationGenerate.RemovePrevStation(CurrentStationId - 1);
            if(CurrentStationId == _stationGenerate.LastStation.StationId - _platformsBeforeGenerate)
                _stationGenerate.GenerateStation(_stationGenerate.LastStation.StationId);
        }

        
    }
}