using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class StationFactory : IStationFactory
    {
        private readonly DiContainer _container;
        private const string STATION_PATH = "Station";
        private List<GameObject> _pool = new List<GameObject>();
        
        public StationFactory(DiContainer container)
        {
            _container = container;
        }
        
        public async UniTask<GameObject> Create(Vector3 at, Quaternion rot)
        {
            var prefab = Resources.Load<GameObject>(STATION_PATH);
            GameObject station = Object.Instantiate(prefab, at, rot);
            _container.InjectGameObject(station);
            _pool.Add(station);
            return  station;
        }
        
        public void CleanUp()
        {
            foreach (var item in _pool)
            {
                Object.Destroy(item);
            }
            _pool.Clear();
        }
    }
}