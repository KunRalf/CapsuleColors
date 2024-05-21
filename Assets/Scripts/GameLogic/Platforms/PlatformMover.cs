using System;
using DG.Tweening;
using GameLogic.Station.Interfaces;
using UnityEngine;

namespace GameLogic.Platforms
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;
        private bool _isAccessToMove;
        
        public void MoveToPoint(Transform target, IPlatformOnStation platformOnStation)
        {
            transform.DOMoveZ(target.position.z, 5f).OnComplete(() => {platformOnStation.EnableNavMesh(false);});
        }
        
        public void AccessToMove(bool isAccess) => _isAccessToMove = isAccess;
    }
}