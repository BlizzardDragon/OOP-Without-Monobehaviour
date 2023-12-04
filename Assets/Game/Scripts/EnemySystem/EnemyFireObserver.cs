using UnityEngine;
using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class EnemyFireObserver : IStartGameListener, IFinishGameListener
    {
        private EnemySpawner _enemySpawner;
        private BulletSpawner _bulletSpawner;
        private BulletPool _bulletPool;
        private EnemyBulletConfigProvider _enemyBulletConfigProvider;


        [Inject]
        public void Construct(
            EnemySpawner enemySpawner,
            BulletSpawner bulletSpawner,
            EnemyBulletConfigProvider enemyBulletConfigProvider,
            BulletPool bulletPool)
        {
            _enemySpawner = enemySpawner;
            _bulletSpawner = bulletSpawner;
            _enemyBulletConfigProvider = enemyBulletConfigProvider;
            _bulletPool = bulletPool;
        }

        public void OnStartGame()
        {
            _enemySpawner.OnEnemySpawned += OnFire;
            _enemySpawner.OnEnemyUnspawned += OnDestroyEnemy;
        }

        public void OnFinishGame()
        {
            _enemySpawner.OnEnemySpawned -= OnFire;
            _enemySpawner.OnEnemyUnspawned -= OnDestroyEnemy;
        }

        private void OnFire(GameObject enemy)
        {
            var agent = enemy.GetComponent<EnemyAttackAgent>();
            agent.OnFire += OnEnemyFire;
        }

        private void OnDestroyEnemy(GameObject enemy)
        {
            var agent = enemy.GetComponent<EnemyAttackAgent>();
            agent.OnFire -= OnEnemyFire;
        }

        public void OnEnemyFire(Vector2 position, Vector2 direction)
        {
            Bullet.Args config = _enemyBulletConfigProvider.GetConfig(position, direction);
            _bulletPool.Spawn(out var obj);
            Bullet bullet = obj.GetComponent<Bullet>();
            _bulletSpawner.SpawnBullet(config, bullet);
        }
    }
}
