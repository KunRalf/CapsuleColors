using Cysharp.Threading.Tasks;
using GameLogic;
using GameLogic.Interfaces;
using GameLogic.Platforms;
using UnityEngine;

namespace Infrastructure.Factories.Interfaces
{
    public interface IPlatformFactory
    {
        void CleanUp();

        PlatformController PlatformController { get; }

        UniTask<PlatformController> Create(LevelStartPositions positions, ILevelLogic lv);
    }
}