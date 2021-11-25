using UnityEngine;

namespace Shake
{
    public class BonusSpeedUp : Bonus
    {
        private float _timerCreateNewSpeedUp;

        private void OnEnable()
        {
            SnakeController.SnakeSpeedUpEvent += CreateBonusSpeedUp;
        }

        private void OnDisable()
        {
            SnakeController.SnakeSpeedUpEvent -= CreateBonusSpeedUp;
        }

        private void Update()
        {
            if (_timerCreateNewSpeedUp > CONSTANTSES.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewSpeedUp = 0;
                CreateBonusSpeedUp(CONSTANTSES.BONUS_SPEED_UP_FIELD_VALUE);
            }

            _timerCreateNewSpeedUp += Time.deltaTime;
        }

        public void CreateBonusSpeedUp(int bonusFieldValue)
        {
            _timerCreateNewSpeedUp = 0;
            CreateBonus(bonusFieldValue);
        }
    }
}
