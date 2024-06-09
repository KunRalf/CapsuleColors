using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ColorsGenerator
    {
        private readonly int _curLevel;

        public ColorsGenerator(int curLevel)
        {
            _curLevel = curLevel;
        }

        public List<Color> GenerateRandomColor()
        {
            List<Color> colors = new List<Color>();
            for (int i = 0; i < _curLevel; i++)
            {
            //    colors;
            }

            return null;
        }
    }
}