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
        private readonly EventsService _eventsService;
        //   private readonly PlatformController _mainPlatform;
        private readonly GameData _gameData;
        public int CurrentStationId { get; private set; }
        private int _platformsBeforeGenerate = 2;
        
        public LevelLogic(IStationGenerate stationGenerate, IPlatformFactory platformFactory, EventsService eventsService)
        {
            _stationGenerate = stationGenerate;
            _platformFactory = platformFactory;
            _eventsService = eventsService;
            _eventsService.TimeEnded += TimeIsOver;
            //TODO: сюда подтянуть сейвер
            _gameData = new GameData(10,0);
        }

        public void TimeIsOver()
        {
            // 
            var Selected = _platformFactory.PlatformController.GetSelectedTiles();
            CurrentStationId = _platformFactory.PlatformController.CurrentStationId;
            _platformFactory.PlatformController.SetNextPoint(_stationGenerate.GetStationById(CurrentStationId + 1));
            //перекидывание капсул
            _stationGenerate.RemovePrevStation(CurrentStationId - 1);
            if(CurrentStationId == _stationGenerate.LastStation.StationId - _platformsBeforeGenerate)
                _stationGenerate.GenerateStation(_stationGenerate.LastStation.StationId);
        }

        
    }
}