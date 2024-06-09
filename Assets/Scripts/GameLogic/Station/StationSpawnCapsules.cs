using System.Collections.Generic;
using GameLogic.Capsule;
using GameLogic.DataObjects.Objects;
using Infrastructure.Factories.Interfaces;
using UnityEngine;

namespace GameLogic.Station
{
    public class StationSpawnCapsules
    {
        private List<Transform> _spawnPoints;
        private readonly ICapsuleFactory _capsuleFactory;
        private List<GameObject> _pool = new List<GameObject>();
        private Vector3 _spawnOffset = new Vector3(0, 0.5f, 0);

        public StationSpawnCapsules(List<Transform> spawnPoints, ICapsuleFactory capsuleFactory, List<ColorPreset> colorPresets)
        {
            _spawnPoints = spawnPoints;
            _capsuleFactory = capsuleFactory;
            SpawnCapsules(colorPresets.Count, colorPresets);
        }

        public void Default()
        {
            foreach (var item in _pool)
            {
                Object.Destroy(item);
            }
            _pool.Clear();
        }
        
        private async void SpawnCapsules(int count, List<ColorPreset> colorPresets)
        {
            for (int i = 0; i < count; i++)
            {
                var capsule = await _capsuleFactory.Create(_spawnPoints[i].position + _spawnOffset);
                capsule.GetComponent<CapsuleController>().Init(colorPresets[i]);
                _pool.Add(capsule);
            }
        }
        
    }
}