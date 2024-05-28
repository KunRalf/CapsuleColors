using UnityEngine;

namespace GameLogic.DataObjects.Objects
{
    [CreateAssetMenu(fileName = "Color", menuName = "Presets/Color", order = 0)]
    public class ColorPreset : ScriptableObject
    {
        [SerializeField] private ColorData _colorData;
        public Color Color => _colorData.Color;
        public TileColors TileTypeColor => _colorData.TileColor;
    }
}