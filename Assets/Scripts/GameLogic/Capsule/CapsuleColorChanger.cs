using UnityEngine;

namespace GameLogic.Capsule
{
    public class CapsuleColorChanger
    {
        private readonly MeshRenderer _meshRenderer;

        public CapsuleColorChanger(MeshRenderer meshRenderer)
        {
            _meshRenderer = meshRenderer;
        }

        public void ChangeColor(Color color)
        {
            _meshRenderer.material.color = color;
        }
    }
}