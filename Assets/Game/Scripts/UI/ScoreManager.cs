using System;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class ScoreManager : IStartGameListener
    {
        private int _score;
        public event Action<int> OnScoreChanged;


        public void OnStartGame() => ActivateScoreEvent();

        public void AddScore()
        {
            _score++;
            ActivateScoreEvent();
        }

        private void ActivateScoreEvent() => OnScoreChanged?.Invoke(_score);
    }
}
