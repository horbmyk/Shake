using UnityEngine;

namespace Shake
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private GameController _gameController;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) & !_gameController.GetStatusGameOver() & !_gameController.GetStatusPause())
                _snakeController.Left();

            if (Input.GetKeyDown(KeyCode.RightArrow) & !_gameController.GetStatusGameOver() & !_gameController.GetStatusPause())
                _snakeController.Right();

            if (Input.GetKeyDown(KeyCode.UpArrow) & !_gameController.GetStatusGameOver() & !_gameController.GetStatusPause())
                _snakeController.Up();

            if (Input.GetKeyDown(KeyCode.DownArrow) & !_gameController.GetStatusGameOver() & !_gameController.GetStatusPause())
                _snakeController.Down();

            if (Input.GetKeyDown(KeyCode.Escape))
                _gameController.Pause();
        }
    }
}
