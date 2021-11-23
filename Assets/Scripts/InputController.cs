using UnityEngine;

namespace Shake
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private SnakeController _snakeController;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                _snakeController.Left();

            if (Input.GetKeyDown(KeyCode.RightArrow))
                _snakeController.Right();

            if (Input.GetKeyDown(KeyCode.UpArrow))
                _snakeController.Up();

            if (Input.GetKeyDown(KeyCode.DownArrow))
                _snakeController.Down();
        }
    }
}
