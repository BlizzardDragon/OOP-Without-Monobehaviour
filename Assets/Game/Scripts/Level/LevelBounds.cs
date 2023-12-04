using System;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class LevelBounds
    {
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _downBorder;
        [SerializeField] private Transform _topBorder;

        public Transform LeftBorder => _leftBorder;
        public Transform RightBorder => _rightBorder;
        public Transform DownBorder => _downBorder;
        public Transform TopBorder => _topBorder;


        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > LeftBorder.position.x
                && positionX < RightBorder.position.x
                && positionY > _downBorder.position.y
                && positionY < _topBorder.position.y;
        }
    }
}