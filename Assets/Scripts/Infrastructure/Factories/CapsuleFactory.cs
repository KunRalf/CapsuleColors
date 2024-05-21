using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class CapsuleFactory : ICapsuleFactory
    {
        private const string CAPSULE_PATH = "Capsule";
        
        private readonly DiContainer _container;
        public GameObject Capsule { get; private set; }

        public CapsuleFactory(DiContainer container)
        {
            _container = container;
        }
        
        public async UniTask<GameObject> Create(Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(CAPSULE_PATH);
            GameObject capsule = Object.Instantiate(prefab, at, Quaternion.identity);
            _container.InjectGameObject(capsule);
            return Capsule = capsule;
        }
    }
}