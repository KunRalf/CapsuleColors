using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using GameLogic;
using GameLogic.Interfaces;
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
      
        public async UniTask<PlatformController> Create(LevelStartPositions positions, ILevelLogic levelLogic)
        {
            var prefab = Resources.Load<GameObject>(PLAFROM_PATH);
            GameObject platform = _container.InstantiatePrefab(prefab, positions.PlatformStartPos,positions.PlatformStartRot, positions.transform.parent);
            _container.InjectGameObject(platform);
            PlatformController = platform.GetComponent<PlatformController>();
            PlatformController.Init(levelLogic);
            return PlatformController;
        }
        
        public void CleanUp()
        {
            Object.Destroy(PlatformController.gameObject);
            PlatformController = null;
        }

       
    }
}