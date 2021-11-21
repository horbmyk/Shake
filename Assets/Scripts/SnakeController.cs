using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class SnakeController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;
        public SnakeController(SnakiesState snakiesState)
        {
            SnakiesState = snakiesState;
        }

        public SnakiesState SnakiesState;
        private Vector2Int _snakeHead;
        private Vector2Int _tmpSnakeHead;
        private List<Vector2Int> _snakeBody;
        private Vector2Int[] _tmpSnakeBody;
        private float _countTimeAutoMuve = 0;
        private const int FREE_FIELD_VALUE = 0;
        private const int SNAKE_HEAD_FIELD_VALUE = 2;
        private const int SNAKE_ITEM_BODY_FIELD_VALUE = 1;
        private const int SNAKE_HEAD_DEFAULT_POSITION_X = 4;
        private const int SNAKE_HEAD_DEFAULT_POSITION_Y = 2;
        private const int SNAKE_ITEM_BODY_DEFAULT_POSITION_X = 4;
        private const int SNAKE_ITEM_BODY_DEFAULT_POSITION_Y = 1;
        private const float TIME_AUTO_MUVE = 1;

        private void Start()
        {
            CreateDefaultSnakeHead();
            CreateDefaultSnakeBody();
            SnakiesState = new RightState();
        }

        private void Update()
        {
            if (_countTimeAutoMuve > TIME_AUTO_MUVE)
            {
                _countTimeAutoMuve = 0;
                AutoMuve();
            }

            _countTimeAutoMuve += Time.deltaTime;
        }
        public void CreateDefaultSnakeHead()
        {
            _snakeHead = new Vector2Int();
            _snakeHead.x = SNAKE_HEAD_DEFAULT_POSITION_X;
            _snakeHead.y = SNAKE_HEAD_DEFAULT_POSITION_Y;
            _fieldController.WriteProgress(_snakeHead, SNAKE_HEAD_FIELD_VALUE);
        }

        public void CreateDefaultSnakeBody()
        {
            _snakeBody = new List<Vector2Int>();
            _snakeBody.Add(new Vector2Int(SNAKE_ITEM_BODY_DEFAULT_POSITION_X, SNAKE_ITEM_BODY_DEFAULT_POSITION_Y));
            _snakeBody.Add(new Vector2Int(SNAKE_ITEM_BODY_DEFAULT_POSITION_X, SNAKE_ITEM_BODY_DEFAULT_POSITION_Y - 1));
            _fieldController.WriteProgress(_snakeBody, SNAKE_ITEM_BODY_FIELD_VALUE);
        }

        public void AutoMuve()
        {
            SnakiesState.Muve();
            //BodyMuve();
        }

        public void Left()
        {
            SnakiesState = new LeftState();//
            _tmpSnakeHead = _snakeHead;
            _snakeHead.y -= 1;
            _fieldController.WriteProgress(_snakeHead, SNAKE_HEAD_FIELD_VALUE);
            BodyMuve();
            //SnakiesState = new LeftState();//
        }

        public void Right()//
        {
            SnakiesState = new RightState();//
            _tmpSnakeHead = _snakeHead;
            _snakeHead.y += 1;
            _fieldController.WriteProgress(_snakeHead, SNAKE_HEAD_FIELD_VALUE);
            BodyMuve();
        }

        public void Up()
        {
            SnakiesState = new UpState();//
            _tmpSnakeHead = _snakeHead;
            _snakeHead.x -= 1;
            _fieldController.WriteProgress(_snakeHead, SNAKE_HEAD_FIELD_VALUE);
            BodyMuve();
        }

        public void Down()
        {
            SnakiesState = new DownState();
            _tmpSnakeHead = _snakeHead;
            _snakeHead.x += 1;
            _fieldController.WriteProgress(_snakeHead, SNAKE_HEAD_FIELD_VALUE);
            BodyMuve();
        }

        private void BodyMuve()
        {
            _tmpSnakeBody = new Vector2Int[_snakeBody.Count];

            for (int i = 0; i < _snakeBody.Count; i++)
                _tmpSnakeBody[i] = _snakeBody[i];

            _snakeBody[0] = new Vector2Int(_tmpSnakeHead.x, _tmpSnakeHead.y);

            for (int i = 1; i < _snakeBody.Count; i++)
                _snakeBody[i] = new Vector2Int(_tmpSnakeBody[i - 1].x, _tmpSnakeBody[i - 1].y);

            _fieldController.WriteProgress(_tmpSnakeBody[_tmpSnakeBody.Length - 1], FREE_FIELD_VALUE);
            _fieldController.WriteProgress(_snakeBody, SNAKE_ITEM_BODY_FIELD_VALUE);
        }
    }
}