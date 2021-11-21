using UnityEngine;

namespace Shake
{
    public class RightState : SnakiesState
    {
        public override void Muve(SnakeController snakeController)
        {
            snakeController.Right();
        }
    }
}
