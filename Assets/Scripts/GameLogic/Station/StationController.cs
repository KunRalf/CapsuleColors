﻿using System;
using System.Collections.Generic;
using GameLogic.DataObjects.Objects;
using GameLogic.Station.Interfaces;
using Infrastructure;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace GameLogic.Station
{
    public class StationController : MonoBehaviour, IStation
    {
        [SerializeField] private List<Transform> _spawnPlaces;
        [SerializeField] private GameObject _blockNavMesh;
        [SerializeField] private List<ColorPreset> _colorsPresets;

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
            _stationSpawnCapsules = new StationSpawnCapsules(_spawnPlaces, _capsuleFactory);
            StationId = id;
            PlatformOnStation(false);
            _eventsService.PlatformOnStation += PlatformOnStation;
            // заполнение билборда
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
     
        private void PlatformOnStation(bool isActive, int id)
        {
            if(id != StationId) return;
            PlatformOnStation(isActive);
        }
    }
}