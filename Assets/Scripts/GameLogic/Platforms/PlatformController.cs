using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic.DataObjects.Objects;
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
        private IStation _currentStation;
        private EventsService _eventsService;

        public int CurrentStationId => _currentStation.StationId;

        [Inject]
        public void Construct(EventsService eventsService)
        {
            _eventsService = eventsService;
        }

        public void Init()
        {
            _platformMover = GetComponent<PlatformMover>();
            _platformMover.AccessToMove(false);
            EnableTiles(new NumberOfAvailableTiles().GetAvailableTiles(1));
        }

        private void EnableTiles(int count)
        {
            WarmUpTiles();
            for (int i = 0; i < count; i++)
            {
                _tiles[i].EnableTile(true);
            }
        }

        private void WarmUpTiles()
        {
            for (int i = 0; i < _tiles.Count; i++)
            {
                _tiles[i].Init(i);
            }
        }
        
        public void SetNextPoint(IStation nextTarget)
        {
            if(nextTarget == null) return;
            _currentStation = nextTarget;
            _platformMover.AccessToMove(true);
            _platformMover.MoveToPoint(nextTarget, PlatformOnStation);
        }

        public List<IPlatformTile> GetSelectedTiles()
        {
            return _tiles.Where(tile => tile.TileColor != TileColors.None).Cast<IPlatformTile>().ToList();
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