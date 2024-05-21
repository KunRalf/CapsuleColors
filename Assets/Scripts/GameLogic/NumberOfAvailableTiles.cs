namespace GameLogic
{
    public struct NumberOfAvailableTiles
    {
        public int GetAvailableTiles(int curLevel)
        {
            return curLevel switch
            {
                1 => 4,
                2 => 8,
                3 => 12,
                4 => 16,
                _ => 0
            };
        }
    }
}