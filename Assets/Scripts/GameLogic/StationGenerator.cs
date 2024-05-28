using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameLogic.Station;
using GameLogic.Station.Interfaces;
using Infrastructure.Factories.Interfaces;
using UnityEngine;

namespace GameLogic
{
    public class StationGenerator : IStationGenerate
    {
        private readonly IStationFactory _stationFactory;
        private readonly LevelStartPositions _startPositions;
        private List<StationController> _pool = new List<StationController>();
        private const int _staionsGenerateCount = 10; 
        private const float _rangeBetweenStations = 60f; 
        public int LastStationId { get; private set; }
        public int StartStationId { get; private set; }
        public IStation FirstStation => _pool[StartStationId];
        public IStation LastStation => _pool[^1];
       

        public StationGenerator(IStationFactory stationFactory, LevelStartPositions startPositions)
        {
            _stationFactory = stationFactory;
            _startPositions = startPositions;
        }

        public async UniTask GenerateStation(int startGeneratedId)
        {
            StartStationId = startGeneratedId;
            Quaternion stationRot = _startPositions.StationStartRot;
            Vector3 spawnPos;
            for (int i = 0; i < _staionsGenerateCount; i++)
            {
                spawnPos = startGeneratedId == 0 ? _startPositions.StationStartPos : NextStationPos(GetLastStationPos());
                startGeneratedId++;
                var station = (await _stationFactory
                    .Create(spawnPos, stationRot)).GetComponent<StationController>();
                station.Init(startGeneratedId);
                _pool.Add(station);
            }
            LastStationId = startGeneratedId;
        }
        
        public void RemovePrevStation(int id)
        {
            StationController prevStation = _pool.FirstOrDefault(_ => _.Id == id);
            if(prevStation == default) return;
            Object.Destroy(prevStation.gameObject);
            _pool.Remove(prevStation);
        }

        private Vector3 GetLastStationPos() => _pool[^1].transform.position;

        private Vector3 NextStationPos(Vector3 lastPos) => new Vector3(lastPos.x, lastPos.y, lastPos.z + _rangeBetweenStations);
        
    }
}