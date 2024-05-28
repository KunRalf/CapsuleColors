using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.Interfaces
{
    public interface ICapsuleFactory
    {
        void CleanUp();
        UniTask<GameObject> Create(Vector3 at);
    }
}