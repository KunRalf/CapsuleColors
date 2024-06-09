using System;
using System.Collections.Generic;
using GameLogic.Interfaces;
using GameLogic.Station.Interfaces;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace GameLogic.Platforms
{
    [RequireComponent(typeof(PlatformMover))]
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private List<PlatformTile> _tiles;
        
        private PlatformMover _platformMover;
        private ILevelLogic _levelLogic;
        private IStation _currentStation;
        private EventsService _eventsService;

        public int CurrentStationId => _currentStation.StationId;

        [Inject]
        public void Construct(EventsService eventsService)
        {
            _eventsService = eventsService;
        }
        
        private void Awake()
        {
            _platformMover = GetComponent<PlatformMover>();
            _platformMover.AccessToMove(false);
            for (int i = 0; i < _tiles.Count; i++)
            {
                _tiles[i].SetIndex(i);
            }
            for (int i = 0; i < new NumberOfAvailableTiles().GetAvailableTiles(1); i++)
            {
                _tiles[i].EnableTile(true);
            }
        }

        public void Init(ILevelLogic levelLogic)
        {
            _levelLogic = levelLogic;
        }
        
        public void SetNextPoint(IStation nextTarget)
        {
            if(nextTarget == null) return;
            _currentStation = nextTarget;
            _platformMover.AccessToMove(true);
            _platformMover.MoveToPoint(nextTarget, PlatformOnStation);
        }
        
        private void PlatformOnStation(bool isAccess)
        {
            foreach (var platformTile in _tiles)
            {
                platformTile.IsAccessToChange = isAccess;
            }
            _eventsService.OnPlatformOnStation(isAccess, _currentStation.StationId);
        }
    }
}