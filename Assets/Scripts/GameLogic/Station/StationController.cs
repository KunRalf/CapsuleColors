using System.Collections.Generic;
using GameLogic.Station.Interfaces;
using Infrastructure;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace GameLogic.Station
{
    public class StationController : MonoBehaviour, IPlatformOnStation
    {
        [SerializeField] private List<Transform> _spawnPlaces;
        [SerializeField] private GameObject _blockNavMesh;

        private StationSpawnCapsules _stationSpawnCapsules;
        private ICapsuleFactory _capsuleFactory;

        [Inject]
        public void Construct(ICapsuleFactory capsuleFactory)
        {
            _capsuleFactory = capsuleFactory;
        }
        
        public void Init()
        {
            _stationSpawnCapsules = new StationSpawnCapsules(_spawnPlaces, _capsuleFactory);
        }

        public void EnableNavMesh(bool isActive) => _blockNavMesh.SetActive(isActive);
    }
}