using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.Interfaces
{
    public interface IStationFactory
    {
        GameObject Station { get; }
        UniTask<GameObject> Create(Vector3 at, Quaternion rot);
    }
}