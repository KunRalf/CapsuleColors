using System.Collections.Generic;
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

        private StationSpawnCapsules _stationSpawnCapsules;
        private ICapsuleFactory _capsuleFactory;

        public Vector3 PlatformStopPos => transform.position;
        public int Id { get; private set; }
        
        [Inject]
        public void Construct(ICapsuleFactory capsuleFactory)
        {
            _capsuleFactory = capsuleFactory;
        }
        
        public void Init(int id)
        {
            _stationSpawnCapsules = new StationSpawnCapsules(_spawnPlaces, _capsuleFactory);
            Id = id;
            PlatformOnStation(true);
            
            // заполнение билборда
        }
        
        public void PlatformOnStation(bool isActive)
        {
            // Включение билборда, таймера и т.д.
            _blockNavMesh.SetActive(isActive);
        } 
    }
}