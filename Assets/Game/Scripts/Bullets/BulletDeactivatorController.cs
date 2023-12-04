using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class BulletDeactivatorController : IFinishGameListener
    {
        private BulletSpawner _bulletSpawner;
        private BulletDeactivator _bulletDeactivator;


        [Inject]
        public void Construct(BulletSpawner bulletSpawner, BulletDeactivator bulletDeactivator)
        {
            _bulletSpawner = bulletSpawner;
            _bulletDeactivator = bulletDeactivator;
        }

        public void OnFinishGame() => _bulletDeactivator.DisableActiveBullets(_bulletSpawner.ActiveBullets);
    }
}
