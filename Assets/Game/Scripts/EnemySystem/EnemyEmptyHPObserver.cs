using UnityEngine;
using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class EnemyEmptyHPObserver : IStartGameListener, IFinishGameListener
    {
        private EnemySpawner _enemySpawner;


        [Inject]
        public void Construct(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }

        public void OnStartGame()
        {
            _enemySpawner.OnEnemySpawned += OnSpawn;
            _enemySpawner.OnEnemyUnspawned += OnUnspawn;
        }

        public void OnFinishGame()
        {
            _enemySpawner.OnEnemySpawned -= OnSpawn;
            _enemySpawner.OnEnemyUnspawned -= OnUnspawn;
        }

        private void OnSpawn(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnEmptyHP += _enemySpawner.UnspawnEnemy;
        }

        private void OnUnspawn(GameObject enemy)
        {
            enemy.GetComponent<HitPointsComponent>().OnEmptyHP -= _enemySpawner.UnspawnEnemy;
        }
    }
}
