using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Interfaces;
using UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class UIFactory : IUIFactory
    {
        private const string UI_ROOT      = "UIRoot";
        private const string HUD      = "HUD";
        
        private readonly DiContainer _container;

        private Canvas _uiRoot;
        private HUDController _hud;

        public UIFactory(DiContainer container)
        {
            _container = container;
        }

        public async UniTask CreateUIRoot()
        {
            var prefab = Resources.Load<GameObject>(UI_ROOT);
            _uiRoot = Object.Instantiate(prefab).GetComponent<Canvas>();
        }

        public async UniTask<HUDController> CreateHUD()
        {
            var prefab = Resources.Load<GameObject>(HUD);
            var hud = Object.Instantiate(prefab, _uiRoot.transform).GetComponent<HUDController>();
            _container.InjectGameObject(hud.gameObject);
            hud.Init();
            _hud = hud;
            return hud;
        }

        public void CleanUp()
        {
            Object.Destroy(_hud.gameObject);
            Object.Destroy(_uiRoot);
            _hud = null;
            _uiRoot = null;
        }
    }
}