using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GameLogic.Capsule;
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
        private List<CapsuleController> _pool = new List<CapsuleController>();
   
        public CapsuleFactory(DiContainer container)
        {
            _container = container;
        }
        

        public async UniTask<CapsuleController> Create(Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(CAPSULE_PATH);
            CapsuleController capsule = Object.Instantiate(prefab, at, Quaternion.identity).GetComponent<CapsuleController>();
            _container.InjectGameObject(capsule.gameObject);
            _pool.Add(capsule);
            return capsule;
        }
        
        
        public void CleanUp()
        {
            foreach (var item in _pool)
            {
                Object.Destroy(item.gameObject);
            }
            _pool.Clear();
        }
    }
}