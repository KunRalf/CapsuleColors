using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.Interfaces
{
    public interface IPlatformFactory
    {
        GameObject Plarform { get; }
        UniTask<GameObject> Create(Vector3 at, Quaternion rot);
    }
}