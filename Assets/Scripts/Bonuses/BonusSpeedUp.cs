using UnityEngine;

namespace Shake
{
    public class BonusSpeedUp : Bonus
    {
        private float _timerCreateNewSpeedUp;
        private float _timerSpeedUp;

        private void OnEnable()
        {
            SnakeController.SpeedUpEvent += GetBonusSpeedUp;
        }

        private void OnDisable()
        {
            SnakeController.SpeedUpEvent -= GetBonusSpeedUp;
        }

        private void Update()
        {
            if (_timerCreateNewSpeedUp > CONSTANTSES.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewSpeedUp = 0;
                CreateBonusSpeedUp(CONSTANTSES.BONUS_SPEED_UP_FIELD_VALUE);
            }

            //if (_timerSpeedUp > CONSTANTSES.MAX_TIME_ACTIVE_BONUS_SPEED_UP)
            //    ManagerTimeScale(CONSTANTSES.DEFAULT_TIME_SCALE);

            _timerCreateNewSpeedUp += Time.deltaTime;
            _timerSpeedUp += Time.deltaTime;
        }

        public void CreateBonusSpeedUp(int bonusFieldValue)
        {
            //_timerCreateNewSpeedUp = 0;
            //CreateBonus(bonusFieldValue);
        }

        public void GetBonusSpeedUp(int bonusFieldValue)
        {
            //ManagerTimeScale(CONSTANTSES.TIME_SCALE_BONUS_SPEED_UP);
            //_timerCreateNewSpeedUp = 0;
            //_timerSpeedUp = 0;
            //CreateBonus(bonusFieldValue);
        }
    }
}
