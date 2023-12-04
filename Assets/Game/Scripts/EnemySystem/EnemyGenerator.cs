using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;
using DG.Tweening;

namespace ShootEmUp
{
    public sealed class EnemyGenerator : IStartGameListener
    {
        private EnemySpawner _enemySpawner;


        [Inject]
        public void Construct(EnemySpawner enemySpawner) => _enemySpawner = enemySpawner;

        public void OnStartGame() => StartSpawn();

        private void StartSpawn()
        {
            DOTween.Sequence()
                .PrependInterval(1)
                .AppendCallback(_enemySpawner.SpawnEnemy)
                .SetLoops(-1);
        }
    }
}