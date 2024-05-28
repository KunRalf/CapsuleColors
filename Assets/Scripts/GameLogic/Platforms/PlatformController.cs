using System;
using System.Collections.Generic;
using GameLogic.Station.Interfaces;
using UnityEngine;

namespace GameLogic.Platforms
{
    [RequireComponent(typeof(PlatformMover))]
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private List<PlatformTile> _tiles;
        
        private PlatformMover _platformMover;

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

        public void SetNextPoint(IStation nextTarget)
        {
            _platformMover.AccessToMove(true);
            _platformMover.MoveToPoint(nextTarget, PlatformOnStation);
        }

        private void PlatformOnStation(bool isAccess)
        {
            foreach (var platformTile in _tiles)
            {
                platformTile.IsAccessToChange = isAccess;
            }
        }
    }
}