using Cysharp.Threading.Tasks;
using GameLogic.Station.Interfaces;

namespace GameLogic
{
    public interface IStationGenerate
    {
        UniTask GenerateStation(int startId);
        int LastStationId { get; }
        int StartStationId { get; }
        IStation FirstStation { get; }
        IStation LastStation { get; }
        void RemovePrevStation(int id);
    }
}