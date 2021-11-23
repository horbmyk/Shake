using UnityEngine;

namespace Shake
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;
        [SerializeField] private SnakeController _snakeController;
        [SerializeField] private BonusController _bonusController;
        //Use Delegales and events INDiscribe
        //Max Count
        //Smart Sprite
        //magic numbers 
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
            _bonusController.CreateBonus();
        }
    }
}
