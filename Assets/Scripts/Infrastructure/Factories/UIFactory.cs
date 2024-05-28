using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Interfaces;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private const string UI_ROOT      = "UIRoot";
        private const string GAMEPLAY_UI      = "GameplayUI";
        
        private readonly DiContainer _container;

        private Canvas _uiRoot;
        
        public UIFactory(DiContainer container)
        {
            _container = container;
        }

        public async UniTask CreateUIRoot()
        {
            var prefab = Resources.Load<GameObject>(UI_ROOT);
            _uiRoot = Object.Instantiate(prefab).GetComponent<Canvas>();
        }

        public async UniTask<GameplayUI> CreateGamePlayUI()
        {
            var prefab = Resources.Load<GameObject>(GAMEPLAY_UI);
            var gamePlayUI = Object.Instantiate(prefab, _uiRoot.transform).GetComponent<GameplayUI>();
            _container.InjectGameObject(gamePlayUI.gameObject);
            gamePlayUI.Init();
            return gamePlayUI;
        }
    }
}