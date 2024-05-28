using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Infrastructure.Factories
{
    public class CapsuleFactory : ICapsuleFactory
    {
        private const string CAPSULE_PATH = "Capsule";
        private readonly DiContainer _container;
        private List<GameObject> _pool = new List<GameObject>();
   
        public CapsuleFactory(DiContainer container)
        {
            _container = container;
        }

        public async UniTask<GameObject> Create(Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(CAPSULE_PATH);
            GameObject capsule = Object.Instantiate(prefab, at, Quaternion.identity);
            _container.InjectGameObject(capsule);
            _pool.Add(capsule);
            return capsule;
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