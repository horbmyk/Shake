using UnityEngine;

namespace Shake
{
    public class DownState : SnakiesState
    {
        public override void Muve(SnakeController snakeController)
        {
            snakeController.Down();
        }
    }
}
