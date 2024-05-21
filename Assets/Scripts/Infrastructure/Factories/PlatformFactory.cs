using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class PlatformFactory : IPlatformFactory
    {
        private readonly DiContainer _container;
        private const string PLAFROM_PATH = "PlayerPlatform";
        
        public GameObject Plarform { get; private set; }

        public PlatformFactory(DiContainer container)
        {
            _container = container;
        }
        
        public async UniTask<GameObject> Create(Vector3 at, Quaternion rot)
        {
            var prefab = Resources.Load<GameObject>(PLAFROM_PATH);
            GameObject platform = Object.Instantiate(prefab, at, rot);
            _container.InjectGameObject(platform);
            return Plarform = platform;
        }
    }
}