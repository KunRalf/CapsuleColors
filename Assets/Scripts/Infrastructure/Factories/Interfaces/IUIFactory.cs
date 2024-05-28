using Cysharp.Threading.Tasks;
using UI;

namespace Infrastructure.Factories.Interfaces
{
    public interface IUIFactory
    {
        UniTask CreateUIRoot();
        UniTask<GameplayUI> CreateGamePlayUI();
    }
}