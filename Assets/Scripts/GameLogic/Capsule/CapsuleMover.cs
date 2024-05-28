using UnityEngine;
using UnityEngine.AI;

namespace GameLogic.Capsule
{
    public class CapsuleMover
    {
        private NavMeshAgent _agent;

        public CapsuleMover(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public void MoveToPoint(Transform pos)
        {
            _agent.SetDestination(pos.position);
        }
    }
}