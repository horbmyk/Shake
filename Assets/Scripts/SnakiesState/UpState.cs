using UnityEngine;

namespace Shake
{
    public class UpState : SnakiesState
    {
        public override void Muve(SnakeController snakeController)
        {
            snakeController.Up();
        }
    }
}
