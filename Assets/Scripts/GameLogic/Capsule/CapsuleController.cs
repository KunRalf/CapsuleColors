using System;
using UnityEngine;

namespace GameLogic.Capsule
{
    public class CapsuleController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        
        private CapsuleColorChanger _capsuleColorChanger;
        private CapsuleReplacer _capsuleReplacer;
        private CapsuleMover _capsuleMover;

        private void Start()
        {
            _capsuleColorChanger = new CapsuleColorChanger(_meshRenderer);
        }

        public void Init(Color color)
        {
            _capsuleColorChanger.ChangeColor(color);   
        }

        private void Update()
        {
          
            
        }
    }
}