using System;
using UnityEngine;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    [Serializable]
    public sealed class LevelBackground : IStartGameListener, IFixedUpdateGameListener
    {
        [SerializeField] private Transform _myTransform;
        [SerializeField] private Params m_params;

        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _startPositionX;
        private float _startPositionZ;


        public void OnStartGame()
        {
            _startPositionY = m_params.m_startPositionY;
            _endPositionY = m_params.m_endPositionY;
            _movingSpeedY = m_params.m_movingSpeedY;
            var position = _myTransform.position;
            _startPositionX = position.x;
            _startPositionZ = position.z;
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _startPositionX,
                    _startPositionY,
                    _startPositionZ
                );
            }

            _myTransform.position -= new Vector3(
                _startPositionX,
                _movingSpeedY * fixedDeltaTime,
                _startPositionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField] public float m_startPositionY = 19;
            [SerializeField] public float m_endPositionY = -38;
            [SerializeField] public float m_movingSpeedY = 5;
        }
    }
}