using System;
using UnityEngine;

namespace GameLogic.Station.Interfaces
{
    public interface IStation
    {
        Vector3 PlatformStopPos { get; }
        void PlatformOnStation(bool isActive);

        void PlatformOnStation(bool isActive, int id);
        int StationId { get; }
    }
}