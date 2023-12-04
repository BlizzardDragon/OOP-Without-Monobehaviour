using FrameworkUnity.OOP.Custom_DI;
using FrameworkUnity.OOP.Interfaces.Listeners;

namespace ShootEmUp
{
    public class ScoreManagerObserver : IInitGameListener, IDeInitGameListener
    {
        private UIScoreView _scoreView;
        private ScoreManager _scoreManager;


        [Inject]
        public void Construct(UIScoreView scoreView, ScoreManager scoreManager)
        {
            _scoreView = scoreView;
            _scoreManager = scoreManager;
        }

        public void OnInitGame() => _scoreManager.OnScoreChanged += UpdateScore;
        public void OnDeInitGame() => _scoreManager.OnScoreChanged -= UpdateScore;

        private void UpdateScore(int score) => _scoreView.UpdateScore(score.ToString());
    }
}
