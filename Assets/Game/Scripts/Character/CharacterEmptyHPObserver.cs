using UnityEngine;
using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;
using FrameworkUnity.OOP.Custom_DI;
using System;

namespace ShootEmUp
{
    [Serializable]
    public class CharacterEmptyHPObserver : IStartGameListener, IFinishGameListener
    {
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        private GameSystem _gameSystem;


        [Inject]
        public void Construct(GameSystem gameManager) => _gameSystem = gameManager;

        public void OnStartGame() => _hitPointsComponent.OnEmptyHP += OnCharacterDeath;
        public void OnFinishGame() => _hitPointsComponent.OnEmptyHP -= OnCharacterDeath;

        private void OnCharacterDeath(GameObject _) => _gameSystem.FinishGame();
    }
}
