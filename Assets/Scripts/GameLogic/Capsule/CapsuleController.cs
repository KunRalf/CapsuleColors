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

        private NavMeshAgent _agent;
        private TileColors _color;
        private CapsuleColorChanger _capsuleColorChanger;
        private CapsuleReplacer _capsuleReplacer;
        private CapsuleMover _capsuleMover;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _capsuleColorChanger = new CapsuleColorChanger(_meshRenderer);
            _capsuleMover = new CapsuleMover(_agent);
        }

        public void Init(ColorPreset colorPreset)
        {
            _capsuleColorChanger.ChangeColor(colorPreset.Color);
            _color = colorPreset.TileTypeColor;
        }


        private void Update()
        {
          
            
        }
    }
}