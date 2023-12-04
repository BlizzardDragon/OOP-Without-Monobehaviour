using UnityEngine;
using FrameworkUnity.OOP.Custom_DI;
using System;

namespace ShootEmUp
{
    [Serializable]
    public class CharacterBulletShooter
    {
        [SerializeField] private WeaponComponent _weapon;
        [SerializeField] private BulletConfig _bulletConfig;
        private BulletSpawner _bulletSpawner;
        private BulletPool _bulletPool;


        [Inject]
        public void Construct(BulletSpawner bulletSpawner, BulletPool bulletPool)
        {
            _bulletSpawner = bulletSpawner;
            _bulletPool = bulletPool;
        }

        public void OnFlyBullet()
        {
            Bullet.Args args = new Bullet.Args
            {
                IsPlayer = true,
                PhysicsLayer = (int)_bulletConfig.PhysicsLayer,
                Color = _bulletConfig.Color,
                Damage = _bulletConfig.Damage,
                Position = _weapon.Position,
                Velocity = _weapon.Rotation * Vector3.up * _bulletConfig.Speed
            };

            _bulletPool.Spawn(out var obj);
            Bullet bullet = obj.GetComponent<Bullet>();
            _bulletSpawner.SpawnBullet(args, bullet);
        }
    }
}
