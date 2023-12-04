using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class BulletRemoveObserver : IFinishGameListener, IStartGameListener
    {
        private BulletSpawner _bulletSpawner;
        private BulletCollisionHandler _bulletCollisionHandler;


        [Inject]
        public void Construct(BulletSpawner bulletSpawner, BulletCollisionHandler bulletCollisionHandler)
        {
            _bulletSpawner = bulletSpawner;
            _bulletCollisionHandler = bulletCollisionHandler;
        }

        public void OnStartGame() => _bulletCollisionHandler.OnBulletRemoved += _bulletSpawner.DespawnBullet;
        public void OnFinishGame() => _bulletCollisionHandler.OnBulletRemoved -= _bulletSpawner.DespawnBullet;
    }
}
