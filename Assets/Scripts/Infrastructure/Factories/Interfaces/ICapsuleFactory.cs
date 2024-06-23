using Cysharp.Threading.Tasks;
using GameLogic.Capsule;
using UnityEngine;

namespace Infrastructure.Factories.Interfaces
{
    public interface ICapsuleFactory
    {
        void CleanUp();
        UniTask<CapsuleController> Create(Vector3 at);
    }
}