using System;
using UnityEngine;
using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    [Serializable]
    public class EnemySystemInstaller : IStartGameListener
    {
        [SerializeField] private int _enemyCount = 7;

        private EnemySpawnPool _enemyPool;
        private EnemyPositions _enemyPositions;


        [Inject]
        public void Construct(EnemySpawnPool enemyPool, EnemyPositions enemyPositions)
        {
            _enemyPool = enemyPool;
            _enemyPositions = enemyPositions;
        }

        public void OnStartGame()
        {
            int positionCount = _enemyPositions.AttackPositionsCount;

            if (positionCount < _enemyCount)
            {
                var message = "The number of enemies exceeds the number of attack points";
                throw new ArgumentOutOfRangeException(nameof(positionCount), message);
            }
            else
            {
                _enemyPool.InstallPool(_enemyCount);
            }
        }
    }
}
