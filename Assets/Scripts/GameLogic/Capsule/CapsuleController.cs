using System;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.Capsule
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CapsuleController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;

        private NavMeshAgent _agent;
        
        private CapsuleColorChanger _capsuleColorChanger;
        private CapsuleReplacer _capsuleReplacer;
        private CapsuleMover _capsuleMover;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _capsuleColorChanger = new CapsuleColorChanger(_meshRenderer);
            _capsuleMover = new CapsuleMover(_agent);
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