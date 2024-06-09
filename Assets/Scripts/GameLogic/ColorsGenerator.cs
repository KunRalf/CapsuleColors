using System.Collections.Generic;
using GameLogic.DataObjects.Objects;
using UnityEngine;


namespace GameLogic
{
    public class ColorsGenerator
    {
        private readonly int _activeTilesCount;
        private readonly List<ColorPreset> _colorsPresets;

        public ColorsGenerator(int activeTilesCount, List<ColorPreset> colorsPresets)
        {
            _activeTilesCount = activeTilesCount;
            _colorsPresets = colorsPresets;
        }

        public List<ColorPreset> GenerateRandomColor()
        {
            List<ColorPreset> colors = new List<ColorPreset>();
            for (int i = 0; i < _activeTilesCount; i++)
            {
                int randomValue = Random.Range(0, _colorsPresets.Count - 1);
                colors.Add(_colorsPresets[randomValue]);
            }

            return colors;
        }
    }
}