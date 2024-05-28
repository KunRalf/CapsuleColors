using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.Interfaces
{
    public interface IStationFactory
    {
        void CleanUp();
        UniTask<GameObject> Create(Vector3 at, Quaternion rot);
    }
}