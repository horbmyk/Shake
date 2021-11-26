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
        public bool _pauseActive;

        //Max Count
        //Smart Sprite
        //Bonus view

        private void Awake()
        {
            _fieldController.InitializationGameField();
            _fieldController.InitializationArrayGameFieldValues();
        }

        private void Start()
        {
            NewGame();
        }

        public void NewGame()
        {
            _fieldController.CreateNewGame();
            _snakeController.CreateDefaultSnakeHead();
            _snakeController.CreateDefaultSnakeBody();
            _snakeController.CreateDefaultSnakeState();
            _bonusBodyGrowUp.CreateBonusGrowUp(CONSTANTSES.BONUS_BODY_GROWUP_FIELD_VALUE);
            _bonusSlowTime.CreateBonusSlowTime(CONSTANTSES.BONUS_SLOW_TIME_FIELD_VALUE);
            _bonusSpeedUp.CreateBonusSpeedUp(CONSTANTSES.BONUS_SPEED_UP_FIELD_VALUE);
            _pauseActive = false;
            Time.timeScale = 1;
            _uiController.Continue();
        }

        public void Pause()
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

        public void Continue()
        {
            _pauseActive = false;
            Time.timeScale = 1;
            _uiController.Continue();
        }

        public void GameOver()
        {
            Time.timeScale = 0;
        }
    }
}
