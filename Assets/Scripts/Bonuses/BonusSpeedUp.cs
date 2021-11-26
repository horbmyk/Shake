using UnityEngine;

namespace Shake
{
    public class BonusSpeedUp : Bonus
    {
        private float _timerCreateNewSpeedUp;
        private float _timerSpeedUp;
        private bool _managerTimeScaleAvailable;

        private void OnEnable()
        {
            SnakeController.SpeedUpEvent += GetBonus;
        }

        private void OnDisable()
        {
            SnakeController.SpeedUpEvent -= GetBonus;
        }

        private void Update()
        {
            if (_timerCreateNewSpeedUp > CONSTANTSES.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewSpeedUp = 0;
                CreateBonusSpeedUp(CONSTANTSES.BONUS_SPEED_UP_FIELD_VALUE);
            }

            if (_timerSpeedUp > CONSTANTSES.MAX_TIME_ACTIVE_BONUS_SPEED_UP & _managerTimeScaleAvailable)
            {
                _managerTimeScaleAvailable = false;
                ManagerTimeScale(CONSTANTSES.DEFAULT_TIME_SCALE);
            }

            _timerCreateNewSpeedUp += Time.deltaTime;
            _timerSpeedUp += Time.deltaTime;
        }

        public void CreateBonusSpeedUp(int bonusFieldValue)
        {
            _timerCreateNewSpeedUp = 0;
            StartCoroutine(CreateBonus(bonusFieldValue));
        }

        public void GetBonus(int bonusFieldValue)
        {
            _managerTimeScaleAvailable = true;
            ManagerTimeScale(CONSTANTSES.TIME_SCALE_BONUS_SPEED_UP);
            _timerSpeedUp = 0;
            ScoreController.Score += CONSTANTSES.BONUS_POINTS;
            CreateBonusSpeedUp(bonusFieldValue);
        }
    }
}
