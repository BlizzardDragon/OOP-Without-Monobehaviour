using UnityEngine;
using System;
using FrameworkUnity.OOP.Interfaces.Listeners;
using FrameworkUnity.OOP.NotMono.GameSystems.SpawnPools;

namespace ShootEmUp
{
    [Serializable]
    public class BulletPool : SpawnPool, IStartGameListener
    {
        [SerializeField, Space(10)] private int _initialCount = 50;

        public void OnStartGame() => InstallPool(_initialCount);
    }
}
