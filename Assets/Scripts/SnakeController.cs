using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class SnakeController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;
        [SerializeField] private GameController _gameController;
        public SnakiesState SnakiesState;
        private Vector2Int _snakeHead;
        private Vector2Int _tmpSnakeHead;
        private List<Vector2Int> _snakeBody;
        private Vector2Int[] _tmpSnakeBody;
        private float _countTimeAutoMuve = 0;
        public delegate void BodyGrowUpEventHandler(int bonusFieldValue);
        public event BodyGrowUpEventHandler BodyGrowUpEvent;
        public delegate void SlowTimeEventHandler(int bonusFieldValue);
        public event SlowTimeEventHandler SlowTimeEvent;
        public delegate void SpeedUpEventHandler(int bonusFieldValue);
        public event SpeedUpEventHandler SpeedUpEvent;
        public int SnakeMovementSpeed { get; set; }
        public SnakeController(SnakiesState snakiesState)
        {
            SnakiesState = snakiesState;
        }

        private void Update()
        {
            if (_countTimeAutoMuve > ((float)1 / SnakeMovementSpeed))
            {
                _countTimeAutoMuve = 0;
                AutoMuve();
            }

            _countTimeAutoMuve += Time.deltaTime;
        }

        public void CreateDefaultSnakeHead()
        {
            _snakeHead = new Vector2Int();
            _snakeHead.x = Constants.SNAKE_HEAD_DEFAULT_POSITION_X;
            _snakeHead.y = Constants.SNAKE_HEAD_DEFAULT_POSITION_Y;
            _fieldController.WriteProgress(_snakeHead, Constants.SNAKE_HEAD_FIELD_VALUE);
        }

        public void CreateDefaultSnakeBody()
        {
            _snakeBody = new List<Vector2Int>();
            _snakeBody.Add(new Vector2Int(Constants.SNAKE_ITEM_BODY_DEFAULT_POSITION_X, Constants.SNAKE_ITEM_BODY_DEFAULT_POSITION_Y));
            _snakeBody.Add(new Vector2Int(Constants.SNAKE_ITEM_BODY_DEFAULT_POSITION_X, Constants.SNAKE_ITEM_BODY_DEFAULT_POSITION_Y - 1));
            _fieldController.WriteProgress(_snakeBody, Constants.SNAKE_ITEM_BODY_FIELD_VALUE);
        }

        public void CreateDefaultSnakeState()
        {
            SnakiesState = new RightState();
        }

        public void AutoMuve()
        {
            SnakiesState.Muve(this);
        }

        public void Left()
        {
            int[,] _arrayValues = _fieldController.GetArrayValues();

            if (_snakeHead.y - 1 < Constants.MINIMUM_POSITION_ON_FIELD
                || _arrayValues[_snakeHead.x, _snakeHead.y - 1] == Constants.SNAKE_ITEM_BODY_FIELD_VALUE)
            {
                _gameController.GameOver();
                return;
            }

            _tmpSnakeHead = _snakeHead;

            switch (_arrayValues[_snakeHead.x, _snakeHead.y - 1])
            {
                case Constants.BONUS_BODY_GROWUP_FIELD_VALUE:
                    SnakeBodyGrowUp();
                    break;

                case Constants.FREE_FIELD_VALUE:
                    BodyMuve();
                    break;

                case Constants.BONUS_SLOW_TIME_FIELD_VALUE:
                    SnakeSlowTime();
                    BodyMuve();
                    break;

                case Constants.BONUS_SPEED_UP_FIELD_VALUE:
                    SnakeSpeedUp();
                    BodyMuve();
                    break;
            }

            _snakeHead.y -= 1;
            _fieldController.WriteProgress(_snakeHead, Constants.SNAKE_HEAD_FIELD_VALUE);
            _countTimeAutoMuve = 0;
            SnakiesState = new LeftState();
        }

        public void Right()
        {
            int[,] _arrayValues = _fieldController.GetArrayValues();

            if (_snakeHead.y + 1 > Constants.MAXIMUM_POSITION_ON_FIELD
                || _arrayValues[_snakeHead.x, _snakeHead.y + 1] == Constants.SNAKE_ITEM_BODY_FIELD_VALUE)
            {
                _gameController.GameOver();
                return;
            }

            _tmpSnakeHead = _snakeHead;

            switch (_arrayValues[_snakeHead.x, _snakeHead.y + 1])
            {
                case Constants.BONUS_BODY_GROWUP_FIELD_VALUE:
                    SnakeBodyGrowUp();
                    break;

                case Constants.FREE_FIELD_VALUE:
                    BodyMuve();
                    break;

                case Constants.BONUS_SLOW_TIME_FIELD_VALUE:
                    SnakeSlowTime();
                    BodyMuve();
                    break;

                case Constants.BONUS_SPEED_UP_FIELD_VALUE:
                    SnakeSpeedUp();
                    BodyMuve();
                    break;
            }

            _snakeHead.y += 1;
            _fieldController.WriteProgress(_snakeHead, Constants.SNAKE_HEAD_FIELD_VALUE);
            _countTimeAutoMuve = 0;
            SnakiesState = new RightState();
        }

        public void Up()
        {
            int[,] _arrayValues = _fieldController.GetArrayValues();

            if (_snakeHead.x - 1 < Constants.MINIMUM_POSITION_ON_FIELD
                || _arrayValues[_snakeHead.x - 1, _snakeHead.y] == Constants.SNAKE_ITEM_BODY_FIELD_VALUE)
            {
                _gameController.GameOver();
                return;
            }

            _tmpSnakeHead = _snakeHead;

            switch (_arrayValues[_snakeHead.x - 1, _snakeHead.y])
            {
                case Constants.BONUS_BODY_GROWUP_FIELD_VALUE:
                    SnakeBodyGrowUp();
                    break;

                case Constants.FREE_FIELD_VALUE:
                    BodyMuve();
                    break;

                case Constants.BONUS_SLOW_TIME_FIELD_VALUE:
                    SnakeSlowTime();
                    BodyMuve();
                    break;

                case Constants.BONUS_SPEED_UP_FIELD_VALUE:
                    SnakeSpeedUp();
                    BodyMuve();
                    break;
            }

            _snakeHead.x -= 1;
            _fieldController.WriteProgress(_snakeHead, Constants.SNAKE_HEAD_FIELD_VALUE);
            _countTimeAutoMuve = 0;
            SnakiesState = new UpState();
        }

        public void Down()
        {
            int[,] _arrayValues = _fieldController.GetArrayValues();

            if (_snakeHead.x + 1 > Constants.MAXIMUM_POSITION_ON_FIELD
                || _arrayValues[_snakeHead.x + 1, _snakeHead.y] == Constants.SNAKE_ITEM_BODY_FIELD_VALUE)
            {
                _gameController.GameOver();
                return;
            }

            _tmpSnakeHead = _snakeHead;

            switch (_arrayValues[_snakeHead.x + 1, _snakeHead.y])
            {
                case Constants.BONUS_BODY_GROWUP_FIELD_VALUE:
                    SnakeBodyGrowUp();
                    break;

                case Constants.FREE_FIELD_VALUE:
                    BodyMuve();
                    break;

                case Constants.BONUS_SLOW_TIME_FIELD_VALUE:
                    SnakeSlowTime();
                    BodyMuve();
                    break;

                case Constants.BONUS_SPEED_UP_FIELD_VALUE:
                    SnakeSpeedUp();
                    BodyMuve();
                    break;
            }

            _snakeHead.x += 1;
            _fieldController.WriteProgress(_snakeHead, Constants.SNAKE_HEAD_FIELD_VALUE);
            _countTimeAutoMuve = 0;
            SnakiesState = new DownState();
        }

        private void BodyMuve()
        {
            _tmpSnakeBody = new Vector2Int[_snakeBody.Count];

            for (int i = 0; i < _snakeBody.Count; i++)
                _tmpSnakeBody[i] = _snakeBody[i];

            _snakeBody[0] = new Vector2Int(_tmpSnakeHead.x, _tmpSnakeHead.y);

            for (int i = 1; i < _snakeBody.Count; i++)
                _snakeBody[i] = new Vector2Int(_tmpSnakeBody[i - 1].x, _tmpSnakeBody[i - 1].y);

            _fieldController.WriteProgress(_tmpSnakeBody[_tmpSnakeBody.Length - 1], Constants.FREE_FIELD_VALUE);
            _fieldController.WriteProgress(_snakeBody, Constants.SNAKE_ITEM_BODY_FIELD_VALUE);
        }

        private void SnakeBodyGrowUp()
        {
            _snakeBody.Insert(0, new Vector2Int(_tmpSnakeHead.x, _tmpSnakeHead.y));
            _fieldController.WriteProgress(_snakeBody, Constants.SNAKE_ITEM_BODY_FIELD_VALUE);
            BodyGrowUpEvent?.Invoke(Constants.BONUS_BODY_GROWUP_FIELD_VALUE);
        }

        private void SnakeSlowTime()
        {
            SlowTimeEvent?.Invoke(Constants.BONUS_SLOW_TIME_FIELD_VALUE);
        }

        private void SnakeSpeedUp()
        {
            SpeedUpEvent?.Invoke(Constants.BONUS_SPEED_UP_FIELD_VALUE);
        }

        public int GetSnakeBody()
        {
            return _snakeBody.Count;
        }
    }
}
