using GameLogic.Station.Interfaces;

namespace GameLogic.Interfaces
{
    public interface ILevelLogic
    {
        void TimeIsOver();

        int CurrentStationId { get; }
    }
}