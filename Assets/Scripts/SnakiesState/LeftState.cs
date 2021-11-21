using UnityEngine;

namespace Shake
{
    public class LeftState : SnakiesState
    {
        public override void Muve(SnakeController snakeController)
        {
            snakeController.Left();
        }
    }
}
