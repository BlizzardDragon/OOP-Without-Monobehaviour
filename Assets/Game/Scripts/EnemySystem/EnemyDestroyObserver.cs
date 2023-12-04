using UnityEngine;
using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class EnemyDestroyObserver : IStartGameListener, IFinishGameListener
    {
        private ScoreManager _scoreManager;
        private EnemySpawner _enemySpawner;


        [Inject]
        public void Construct(ScoreManager scoreManager,
            EnemySpawner enemySpawner)
        {
            _scoreManager = scoreManager;
            _enemySpawner = enemySpawner;
        }

        public void OnStartGame() => _enemySpawner.OnEnemyUnspawned += OnDestroyEnemy;
        public void OnFinishGame() => _enemySpawner.OnEnemyUnspawned -= OnDestroyEnemy;

        public void OnDestroyEnemy(GameObject enemy) => _scoreManager.AddScore();
    }
}
