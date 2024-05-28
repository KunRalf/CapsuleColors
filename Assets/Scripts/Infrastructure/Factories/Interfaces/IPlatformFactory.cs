using Cysharp.Threading.Tasks;
using GameLogic.Platforms;
using UnityEngine;

namespace Infrastructure.Factories.Interfaces
{
    public interface IPlatformFactory
    {
        void CleanUp();

        PlatformController PlatformController { get; }
        
        UniTask<PlatformController> Create(Vector3 at, Quaternion rot);
    }
}