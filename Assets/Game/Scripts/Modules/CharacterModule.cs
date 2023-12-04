using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Custom_DI.Internal;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterModule : GameModule
    {
        [Listener]
        [SerializeField]
        private CharacterMoveController _moveController;

        [Listener]
        [SerializeField]
        private CharacterEmptyHPObserver _emptyHPObserver = new();

        [Service]
        [Listener]
        [SerializeField]
        private CharacterBulletShooter _bulletShooter = new();

        [Listener]
        private CharacterFireController _fireController = new();

        [Service]
        [Listener]
        [SerializeField]
        private PlayerInput _input;
    }
}
