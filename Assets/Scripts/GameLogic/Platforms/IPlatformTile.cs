using GameLogic.DataObjects.Objects;

namespace GameLogic.Platforms
{
    public interface IPlatformTile
    {
        int Index { get; }
        TileStatus TileStatus { get; }
        TileColors TileColor { get; }
    }
}