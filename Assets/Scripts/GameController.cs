using UnityEngine;

namespace Shake
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private BonusBodyGrowUp _bonusBodyGrowUp;
        [SerializeField] private BonusSlowTime _bonusSlowTime;

        //Max Count
        //Smart Sprite

        private void Awake()
        {
            _fieldController.InitializationGameField();
            _fieldController.InitializationArrayGameFieldValues();
        }

        private void Start()
        {
            //_fieldController.LoadProgress();
            //_fieldController.RefreshColorGameFieldCells();
            _fieldController.CreateNewGame();//
            _snakeController.CreateDefaultSnakeHead();
            _snakeController.CreateDefaultSnakeBody();
            _bonusBodyGrowUp.CreateBonus(CONSTANTSES.BONUS_FOOD_FIELD_VALUE);
            _bonusSlowTime.CreateBonus(CONSTANTSES.BONUS_SLOW_TIME_FIELD_VALUE);
            //_bonusSlowTime.CreateBonus(CONSTANTSES.BONUS_SLOW_TIME_FIELD_VALUE);
        }
    }
}
