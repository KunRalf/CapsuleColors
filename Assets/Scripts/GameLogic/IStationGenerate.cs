using Cysharp.Threading.Tasks;
using GameLogic.Interfaces;
using GameLogic.Station.Interfaces;

namespace GameLogic
{
    public interface IStationGenerate
    {
        UniTask GenerateStation(int startId);
        IStation FirstStation { get; }
        IStation LastStation { get; }
        IStation GetStationById(int id);
        void RemovePrevStation(int id);
    }
}