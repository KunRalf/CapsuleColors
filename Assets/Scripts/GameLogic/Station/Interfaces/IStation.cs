using UnityEngine;

namespace GameLogic.Station.Interfaces
{
    public interface IStation
    {
        Vector3 PlatformStopPos { get; }
        void PlatformOnStation(bool isActive);
    }
}