using System;
using GameLogic.DataObjects.Objects;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.Capsule
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CapsuleController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        private int _tileBindingIndex = -1;
        private NavMeshAgent _agent;
        private TileColors _color;
        private CapsuleColorChanger _capsuleColorChanger;
        private CapsuleReplacer _capsuleReplacer;
        private CapsuleMover _capsuleMover;

        public int TileBindingIndex => _tileBindingIndex;

        public void Init(ColorPreset colorPreset)
        {
            _agent = GetComponent<NavMeshAgent>();
            _capsuleColorChanger = new CapsuleColorChanger(_meshRenderer);
            _capsuleMover = new CapsuleMover(_agent);
            _capsuleColorChanger.ChangeColor(colorPreset.Color);
            _color = colorPreset.TileTypeColor;
        }

        public void SetTileBindingIndex(int index)
        {
            _tileBindingIndex = index;
        }

        private void Update()
        {
          
            
        }
    }
}