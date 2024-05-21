using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.Interfaces
{
    public interface ICapsuleFactory
    {
        GameObject Capsule { get; }
        UniTask<GameObject> Create(Vector3 at);
    }
}