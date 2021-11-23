using UnityEngine;

namespace Shake
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private BonusController _bonusController;
  
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
            _bonusController.CreateBonus(CONSTANTSES.BONUS_FOOD_FIELD_VALUE);
            _bonusController.CreateBonus(CONSTANTSES.BONUS_SLOW_TIME_FIELD_VALUE);
            //_bonusSlowTime.CreateBonus(CONSTANTSES.BONUS_SLOW_TIME_FIELD_VALUE);
        }
    }
}
