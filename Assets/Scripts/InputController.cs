using UnityEngine;

namespace Shake
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private GameController _gameController;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) & !_gameController._pauseActive & !_gameController._gameOver)
                _snakeController.Left();

            if (Input.GetKeyDown(KeyCode.RightArrow) & !_gameController._pauseActive & !_gameController._gameOver)
                _snakeController.Right();

            if (Input.GetKeyDown(KeyCode.UpArrow) & !_gameController._pauseActive & !_gameController._gameOver)
                _snakeController.Up();

            if (Input.GetKeyDown(KeyCode.DownArrow) & !_gameController._pauseActive & !_gameController._gameOver)
                _snakeController.Down();

            if (Input.GetKeyDown(KeyCode.Escape))
                _gameController.Pause();
        }
    }
}
