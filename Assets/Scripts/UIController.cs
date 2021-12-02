using UnityEngine;
using UnityEngine.UI;

namespace Shake
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private ScoreController _scoreController;
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private GameController _gameController;
        [SerializeField] private GameObject _pause;
        [SerializeField] private GameObject _gameOver;
        [SerializeField] private Text _score;
        [SerializeField] private Text _lenth;
        [SerializeField] private Text _timerCurentGame;
        private string _timerFormat;



        private void Awake()
        {
            _pause.SetActive(false);
            _gameOver.SetActive(false);
        }

        private void Update()
        {
            _score.text = "Score : " + _scoreController.ScoreCount;
            _lenth.text = "Lenth : " + _snakeController.GetSnakeBody();
            _timerCurentGame.text = "Timer " + FormateTime(_gameController.GetTimerCurentGame());
        }

        private string FormateTime(float incomingTime)
        {
            string timerFormat = "";
            int seconds = (int)(incomingTime % 60);
            int minutes = (int)(incomingTime / 60) % 60;
            int hours = (int)(incomingTime / 3600) % 24;
            return timerFormat = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);
        }

        public void Pause()
        {
            _pause.SetActive(true);
            _gameOver.SetActive(false);
        }

        public void Continue()
        {
            _pause.SetActive(false);
            _gameOver.SetActive(false);
        }

        public void GameOver()
        {
            _gameOver.SetActive(true);
        }
    }
}
