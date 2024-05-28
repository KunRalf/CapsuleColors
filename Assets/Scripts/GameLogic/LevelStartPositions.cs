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
        
        public Vector3 StationStartPos => _stantionStartPoint.position;
        public Quaternion StationStartRot => _stantionStartPoint.rotation;
        
    }
}