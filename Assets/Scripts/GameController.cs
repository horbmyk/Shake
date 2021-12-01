using UnityEngine;

namespace Shake
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private BonusBodyGrowUp _bonusBodyGrowUp;
        [SerializeField] private BonusSlowTime _bonusSlowTime;
        [SerializeField] private BonusSpeedUp _bonusSpeedUp;
        [SerializeField] private UIController _uiController;
        [SerializeField] private ScoreController _scoreController;
        private float _timerCurentGame { get; set; }
        private bool _pauseActive;
        private bool _gameOverActive;

        private void Awake()
        {
            _fieldController.InitializationGameField();
            _fieldController.InitializationArrayGameFieldValues();
        }

        private void Start()
        {
            NewGame();
        }

        private void Update()
        {
            _timerCurentGame += Time.deltaTime;
        }

        public void NewGame()
        {
            _fieldController.CreateNewGame();
            _snakeController.CreateDefaultSnakeHead();
            _snakeController.CreateDefaultSnakeBody();
            _snakeController.CreateDefaultSnakeState();
            _bonusBodyGrowUp.CreateBonusGrowUp(Constants.BONUS_BODY_GROWUP_FIELD_VALUE);
            _bonusSlowTime.CreateBonusSlowTime(Constants.BONUS_SLOW_TIME_FIELD_VALUE);
            _bonusSpeedUp.CreateBonusSpeedUp(Constants.BONUS_SPEED_UP_FIELD_VALUE);
            _pauseActive = false;
            _gameOverActive = false;
            Time.timeScale = 1;
            _uiController.Continue();
            _timerCurentGame = 0;
            _scoreController.Score = 0;
        }

        public void Pause()
        {
            if (!_gameOverActive)
            {
                if (!_pauseActive)
                {
                    Time.timeScale = 0;
                    _uiController.Pause();
                }
                else
                {
                    Time.timeScale = 1;
                    _uiController.Continue();
                }

                _pauseActive = !_pauseActive;
            }
        }

        public void Continue()
        {
            _pauseActive = false;
            Time.timeScale = 1;
            _uiController.Continue();
        }

        public void GameOver()
        {
            _gameOverActive = true;
            Time.timeScale = 0;
            _uiController.GameOver();
        }

        public float GetTimerCurentGame()
        {
            return _timerCurentGame;
        }

        public bool GetStatusPause()
        {
            return _pauseActive;
        }

        public bool GetStatusGameOver()
        {
            return _gameOverActive;
        }
    }
}
