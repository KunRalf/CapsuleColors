using System;

namespace GameLogic.DataObjects
{
    public class GameData
    {
        private int _lifes;
        private int _coins;

        public int Lifes => _lifes;
        public int Coins => _coins;

        public event Action LifesIsOver; 
        public event Func<int, int> CoinCountChanged; 
        
        public GameData(int lifes, int coins)
        {
            _lifes = lifes;
            _coins = coins;
        }

        public void ChangeLifes(int value)
        {
            _lifes += value;
            if (_lifes <= 0)
            {
                _lifes = 0;
                LifesIsOver?.Invoke();
            }
        }

        public void ChangeCountCoins(int value)
        {
            _coins += value;
            CoinCountChanged?.Invoke(_coins);
        }
    }
}