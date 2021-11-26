using UnityEngine;
using UnityEngine.UI;

namespace Shake
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private ScoreController _scoreController;
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private GameObject _pause;
        [SerializeField] private GameObject _gameOver;
        [SerializeField] private Text _score;
        [SerializeField] private Text _lenth;


        private void Awake()
        {
            _pause.SetActive(false);
            _gameOver.SetActive(false);
        }

        private void Update()
        {
            _score.text = "Score : " + _scoreController.Score;
            _lenth.text = "Lenth : " + _snakeController.GetSnakeBody();
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
