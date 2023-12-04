using System.Collections.Generic;
using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class BulletBoundaryChecker : IFixedUpdateGameListener
    {
        private LevelBounds _levelBounds;
        private BulletSpawner _bulletSpawner;

        private readonly List<Bullet> _cache = new();


        [Inject]
        public void Construct(LevelBounds levelBounds, BulletSpawner bulletSpawner)
        {
            _levelBounds = levelBounds;
            _bulletSpawner = bulletSpawner;
        }

        public void OnFixedUpdate(float fixedDeltaTime) => CheckOutBounds();

        private void CheckOutBounds()
        {
            _cache.Clear();
            _cache.AddRange(_bulletSpawner.ActiveBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                Bullet bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    _bulletSpawner.DespawnBullet(bullet);
                }
            }
        }
    }
}
