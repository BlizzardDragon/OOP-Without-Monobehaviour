using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class BulletSpawnerObserver : IFinishGameListener, IStartGameListener
    {
        private BulletSpawner _bulletSpawner;
        private BulletPool _bulletPool;
        private BulletCollisionHandler _bulletCollisionHandler;


        [Inject]
        public void Construct(BulletSpawner bulletSpawner, BulletPool bulletPool, BulletCollisionHandler bulletCollisionHandler)
        {
            _bulletSpawner = bulletSpawner;
            _bulletPool = bulletPool;
            _bulletCollisionHandler = bulletCollisionHandler;
        }

        public void OnStartGame()
        {
            _bulletSpawner.OnBulletSpawned += OnSpawnBullet;
            _bulletSpawner.OnBulletDespawned += OnDespawnBullet;
        }

        public void OnFinishGame()
        {
            _bulletSpawner.OnBulletSpawned -= OnSpawnBullet;
            _bulletSpawner.OnBulletDespawned -= OnDespawnBullet;
        }

        private void OnSpawnBullet(Bullet bullet)
        {
            bullet.OnCollisionEntered += _bulletCollisionHandler.HandleCollision;
        }

        private void OnDespawnBullet(Bullet bullet)
        {
            bullet.OnCollisionEntered -= _bulletCollisionHandler.HandleCollision;
            _bulletPool.Unspawn(bullet.gameObject);
        }
    }
}
