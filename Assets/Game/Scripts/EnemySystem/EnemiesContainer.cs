using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemiesContainer
    {
        public HashSet<GameObject> ActiveEnemies => _activeEnemies;
        private readonly HashSet<GameObject> _activeEnemies = new();


        public void AddActiveEnemy(GameObject enemy) => _activeEnemies.Add(enemy);
    }
}
