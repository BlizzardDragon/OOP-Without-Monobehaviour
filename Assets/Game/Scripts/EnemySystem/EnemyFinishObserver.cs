using UnityEngine;
using FrameworkUnity.OOP.Custom_DI;

namespace ShootEmUp
{
    public class EnemyFinishObserver
    {
        private EnemiesContainer _enemiesContainer;
        private EnemySpawner _enemySpawner;


        [Inject]
        public void Construct(EnemiesContainer enemiesContainer, EnemySpawner enemyDeactivator)
        {
            _enemiesContainer = enemiesContainer;
            _enemySpawner = enemyDeactivator;
        }

        public void OnFinishGame()
        {
            foreach (var enemy in _enemiesContainer.ActiveEnemies)
            {
                _enemySpawner.UnspawnEnemy(enemy);
            }
        }
    }
}
