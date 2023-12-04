using UnityEngine;
using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;
using System;

namespace ShootEmUp
{
    [Serializable]
    public sealed class CharacterMoveController : IFixedUpdateGameListener, IStartGameListener, IFinishGameListener
    {
        [SerializeField] Transform _character;
        [SerializeField] private MoveComponent _moveComponent;
        private PlayerInput _playerInput;
        private LevelBounds _levelBounds;
        private int _horizontalDirection;


        [Inject]
        public void Construct(PlayerInput playerInput, LevelBounds levelBounds)
        {
            _playerInput = playerInput;
            _levelBounds = levelBounds;
        }

        public void OnStartGame() => _playerInput.OnMove += SetHorizontalDirection;
        public void OnFinishGame() => _playerInput.OnMove -= SetHorizontalDirection;

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            var direction = new Vector2(_horizontalDirection, 0) * fixedDeltaTime;

            if (_character.position.x < _levelBounds.LeftBorder.position.x)
            {
                if (direction.x < 0) return;
            }
            else if (_character.position.x > _levelBounds.RightBorder.position.x)
            {
                if (direction.x > 0) return;
            }
            
            _moveComponent.Move(direction);
        }

        private void SetHorizontalDirection(int direction) => _horizontalDirection = direction;
    }
}
