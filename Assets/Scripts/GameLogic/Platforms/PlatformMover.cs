﻿using System;
using DG.Tweening;
using GameLogic.Station.Interfaces;
using UnityEngine;

namespace GameLogic.Platforms
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private bool _isAccessToMove;
        
        public void MoveToPoint(IStation target, Action<bool> action)
        {
            if(!_isAccessToMove) return;
            action?.Invoke(false);
            transform.DOMoveZ(target.PlatformStopPos.z, 5f).OnComplete(() =>
            {
                action?.Invoke(true);
            });
        }
        
        public void AccessToMove(bool isAccess) => _isAccessToMove = isAccess;
    }
}