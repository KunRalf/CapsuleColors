using System;
using UnityEngine;

namespace GameLogic
{
    public class LevelStartPositions : MonoBehaviour
    {
        [SerializeField] private Transform _platfromStartPoint;
        [SerializeField] private Transform _stantionStartPoint;

        public Vector3 PlatformStartPos => _platfromStartPoint.position;
        public Quaternion PlatformStartRot => _platfromStartPoint.rotation;
        
        public Vector3 StantionStartPos => _stantionStartPoint.position;
        public Quaternion StantionStartRot => _stantionStartPoint.rotation;
        
    }
}