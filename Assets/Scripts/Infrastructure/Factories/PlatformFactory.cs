using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using GameLogic.Platforms;
using Infrastructure.Factories.Interfaces;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class PlatformFactory : IPlatformFactory
    {
        private readonly DiContainer _container;
        private const string PLAFROM_PATH = "PlayerPlatform";
        
        public PlatformController PlatformController { get; private set; }
        
      public PlatformFactory(DiContainer container)
        {
            _container = container;
        }
      
        public async UniTask<PlatformController> Create(Vector3 at, Quaternion rot)
        {
            var prefab = Resources.Load<GameObject>(PLAFROM_PATH);
            GameObject platform = Object.Instantiate(prefab, at, rot);
            _container.InjectGameObject(platform);
            return PlatformController = platform.GetComponent<PlatformController>();
        }
        
        public void CleanUp()
        {
            Object.Destroy(PlatformController.gameObject);
            PlatformController = null;
        }

       
    }
}