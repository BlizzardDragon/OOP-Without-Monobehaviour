using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Custom_DI.Internal;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySystemModule : GameModule
    {
        [Service]
        [SerializeField]
        private EnemySpawnPool _spawnPool;
    
        [Listener]
        [SerializeField]
        private EnemySystemInstaller _systemInstaller;
    
        [Service]
        [Listener]
        [SerializeField]
        private EnemySpawner _spawner;
    
        [Service]
        [Listener]
        [SerializeField]
        private EnemyPositions _positions;
    
        [Service]
        private EnemyBulletConfigProvider _bulletConfigProvider = new();
    
        [Service]
        private EnemiesContainer _container = new();
    
        [Listener]
        private EnemyDestroyObserver _destroyObserver = new();
    
        [Listener]
        private EnemyEmptyHPObserver _emptyHPObserver = new();
    
        [Listener]
        private EnemyFireObserver _fireObserver = new();
    
        [Listener]
        private EnemyFinishObserver _finishObserver = new();

        [Listener]
        private EnemyGenerator _generator = new();
    }
}