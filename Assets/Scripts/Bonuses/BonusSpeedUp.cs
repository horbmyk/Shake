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
            if (_timerCreateNewSpeedUp > Constants.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewSpeedUp = 0;
                CreateBonusSpeedUp(Constants.BONUS_SPEED_UP_FIELD_VALUE);
            }

            if (_timerSpeedUp > Constants.MAX_TIME_ACTIVE_BONUS_SPEED_UP & _managerTimeScaleAvailable)
            {
                _managerTimeScaleAvailable = false;
                ManagerTimeScale(Constants.DEFAULT_TIME_SCALE);
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
            ManagerTimeScale(Constants.TIME_SCALE_BONUS_SPEED_UP);
            _timerSpeedUp = 0;
            AddScore(Constants.BONUS_POINTS);
            PlaySoundFood();
            CreateBonusSpeedUp(bonusFieldValue);
        }
    }
}
