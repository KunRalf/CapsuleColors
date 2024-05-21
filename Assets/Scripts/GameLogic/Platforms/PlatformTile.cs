using System;
using UnityEngine;

namespace GameLogic.Platforms
{
    [RequireComponent(typeof(MeshRenderer))]
    public class PlatformTile : MonoBehaviour
    {
        [SerializeField] private Color _defaultColor;
        [SerializeField] private int _index;

        private MeshRenderer _meshRenderer;
        
        public int Index => _index;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetIndex(int index)
        {
            _index = index;
        }

        public void SetTileColor(Color color)
        {
            if (_meshRenderer.material.color == color)
                DefaultColor();
            else
                _meshRenderer.material.color = color;
        }

        public void EnableTile(bool isActive) => gameObject.SetActive(isActive);
        
        private void DefaultColor()
        {
            _meshRenderer.material.color = _defaultColor;
        }
    }
}