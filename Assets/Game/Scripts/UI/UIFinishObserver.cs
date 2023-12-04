using UnityEngine;
using FrameworkUnity.OOP.Interfaces.Listeners;
using System;

namespace ShootEmUp
{
    [Serializable]
    public class UIFinishObserver : IFinishGameListener
    {
        [SerializeField] private GameObject _gameOverUI;

        public void OnFinishGame() => _gameOverUI.SetActive(true);
    }
}
