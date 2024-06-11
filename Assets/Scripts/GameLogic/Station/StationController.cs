using System.Collections.Generic;
using GameLogic.DataObjects.Objects;
using GameLogic.Station.Biliboard;
using GameLogic.Station.Interfaces;
using Infrastructure.Factories.Interfaces;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace GameLogic.Station
{
    public class StationController : MonoBehaviour, IStation
    {
        [SerializeField] private List<Transform> _spawnPlaces;
        [SerializeField] private GameObject _blockNavMesh;
        [SerializeField] private List<ColorPreset> _colorsPresets;
        [SerializeField] private BillboardController _billboardController;
        
        private StationSpawnCapsules _stationSpawnCapsules;
        private ICapsuleFactory _capsuleFactory;
        private EventsService _eventsService;

        public Vector3 PlatformStopPos => transform.position;
        public int StationId { get; private set; }
        
        [Inject]
        public void Construct(ICapsuleFactory capsuleFactory, EventsService eventsService)
        {
            _capsuleFactory = capsuleFactory;
            _eventsService = eventsService;
        }
        
        public void Init(int id)
        {
            ColorsGenerator colorsGenerator = new ColorsGenerator(new NumberOfAvailableTiles().GetAvailableTiles(1/* TODO: сюда из сейвера текущий уровень платформы */), _colorsPresets);
            List<ColorPreset> colorsPresets = colorsGenerator.GenerateRandomColor();
            _stationSpawnCapsules = new StationSpawnCapsules(_spawnPlaces, _capsuleFactory, colorsPresets);
            _billboardController.Init(colorsPresets);
            StationId = id;
            PlatformOnStation(false);
            _eventsService.PlatformOnStation += PlatformOnStation;
        }

        private void OnDestroy()
        {
            _eventsService.PlatformOnStation -= PlatformOnStation;
        }

        public void PlatformOnStation(bool isActive)
        {
            // Включение билборда, таймера и т.д.
            _blockNavMesh.SetActive(!isActive);
        }
        
        public void Default()
        {
            _stationSpawnCapsules.Default();
            _blockNavMesh.SetActive(true);
        }
     
        public void PlatformOnStation(bool isActive, int id)
        {
            if(id != StationId) return;
            PlatformOnStation(isActive);
        }
    }
}