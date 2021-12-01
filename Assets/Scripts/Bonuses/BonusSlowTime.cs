using UnityEngine;

namespace Shake
{
    public class BonusSlowTime : Bonus
    {
        private float _timerCreateNewSlowTime;
        private float _timerSlowTime;
        private bool _managerTimeScaleAvailable;
        private void OnEnable()
        {
            SnakeController.SlowTimeEvent += GetBonus;
        }

        private void OnDisable()
        {
            SnakeController.SlowTimeEvent -= GetBonus;
        }

        private void Update()
        {
            if (_timerCreateNewSlowTime > Constants.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewSlowTime = 0;
                CreateBonusSlowTime(Constants.BONUS_SLOW_TIME_FIELD_VALUE);
            }

            if (_timerSlowTime > Constants.MAX_TIME_ACTIVE_BONUS_SLOW_TIME && _managerTimeScaleAvailable)
            {
                _managerTimeScaleAvailable = false;
                ManagerTimeScale(Constants.DEFAULT_TIME_SCALE);
            }

            _timerCreateNewSlowTime += Time.deltaTime;
            _timerSlowTime += Time.deltaTime;
        }

        public void CreateBonusSlowTime(int bonusFieldValue)
        {
            _timerCreateNewSlowTime = 0;
            StartCoroutine(CreateBonus(bonusFieldValue));
        }

        public void GetBonus(int bonusFieldValue)
        {
            _managerTimeScaleAvailable = true;
            ManagerTimeScale(Constants.TIME_SCALE_BONUS_SLOW_TIME);
            _timerSlowTime = 0;
            AddScore(Constants.BONUS_POINTS);
            PlaySoundFood();
            CreateBonusSlowTime(bonusFieldValue);
        }
    }
}
