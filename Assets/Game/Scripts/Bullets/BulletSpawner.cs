using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public sealed class BulletSpawner
    {
        private readonly HashSet<Bullet> _activeBullets = new();
        public HashSet<Bullet> ActiveBullets => _activeBullets;

        public event Action<Bullet> OnBulletSpawned;
        public event Action<Bullet> OnBulletDespawned;


        public void SpawnBullet(Bullet.Args args, Bullet bullet)
        {
            bullet.SetPosition(args.Position);
            bullet.SetColor(args.Color);
            bullet.SetPhysicsLayer(args.PhysicsLayer);
            bullet.Damage = args.Damage;
            bullet.IsPlayer = args.IsPlayer;
            bullet.SetVelocity(args.Velocity);

            _activeBullets.Add(bullet);
            OnBulletSpawned?.Invoke(bullet);
        }

        public void DespawnBullet(Bullet bullet)
        {
            _activeBullets.Remove(bullet);
            OnBulletDespawned?.Invoke(bullet);
        }
    }
}