using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Custom_DI.Internal;
using UnityEngine;

namespace ShootEmUp
{
    public class UIModule : GameModule
    {
        [Service]
        [SerializeField]
        private UIScoreView _uIScoreView;

        [Listener]
        [SerializeField]
        private UIFinishObserver _uIFinishObserver = new();

        [Listener]
        private ScoreManagerObserver _scoreManagerObserver = new();
    }
}