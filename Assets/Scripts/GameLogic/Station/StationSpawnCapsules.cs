using System.Collections.Generic;
using Infrastructure.Factories.Interfaces;
using UnityEngine;

namespace GameLogic.Station
{
    public class StationSpawnCapsules
    {
        private List<Transform> _spawnPoints;
        private readonly ICapsuleFactory _capsuleFactory;
        private List<GameObject> _pool = new List<GameObject>();

        public StationSpawnCapsules(List<Transform> spawnPoints, ICapsuleFactory capsuleFactory)
        {
            _spawnPoints = spawnPoints;
            _capsuleFactory = capsuleFactory;
            SpawCapsules(4);
        }

        private async void SpawCapsules(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var capsule = await _capsuleFactory.Create(_spawnPoints[i].position);
                _pool.Add(capsule);
            }
        }
    }
}