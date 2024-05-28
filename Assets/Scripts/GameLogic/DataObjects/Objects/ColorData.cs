using System;
using UnityEngine;

namespace GameLogic.DataObjects.Objects
{
    [Serializable]
    public class ColorData
    {
        [SerializeField] private Color _color;
        [SerializeField] private TileColors _tileColor;

        public Color Color => _color;
        public TileColors TileColor => _tileColor;

        public ColorData(Color color, TileColors tileColors)
        {
            _color = color;
            _tileColor = tileColors;
        }
    }
}