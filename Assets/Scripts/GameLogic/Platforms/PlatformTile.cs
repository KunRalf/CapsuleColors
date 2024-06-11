using System;
using GameLogic.DataObjects.Objects;
using UnityEngine;

namespace GameLogic.Platforms
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PlatformTile : MonoBehaviour, IPlatformTile
    {
        [SerializeField] private ColorPreset _defaultColor;
        [SerializeField] private int _index;

        [SerializeField] private ColorPreset _colorData;
        private MeshRenderer _meshRenderer;
        private bool _isAccessToChange;
        
        public int Index => _index;
        public TileStatus TileStatus { get; private set; }
        public TileColors TileColor => _colorData.TileTypeColor;

        public bool IsAccessToChange
        {
            get => _isAccessToChange;
            set => _isAccessToChange = value;
        }

        public void Init(int index)
        {
            _index = index;
            _meshRenderer = GetComponent<MeshRenderer>();
            DefaultColor();
        }

        public void SetTileColor(ColorPreset colorData)
        {
            if(!_isAccessToChange) return;
            if (_colorData.TileTypeColor == colorData.TileTypeColor)
                DefaultColor();
            else
            {
                _colorData = colorData;
                _meshRenderer.material.color = _colorData.Color;
            }
        }

        public void EnableTile(bool isActive) => gameObject.SetActive(isActive);
        
        private void DefaultColor()
        {
            _colorData = _defaultColor;
            _meshRenderer.material.color = _colorData.Color;
        }
    }
}