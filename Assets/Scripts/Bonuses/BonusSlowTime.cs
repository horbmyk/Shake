using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class BonusSlowTime : Bonus
    {
        private float _timerCreateNewSlowTime;
        private float _timerSlowTime;
        private void OnEnable()
        {
            SnakeController.SlowTimeEvent += GetBonusSlowTime;
        }

        private void OnDisable()
        {
            SnakeController.SlowTimeEvent -= GetBonusSlowTime;
        }

        private void Update()
        {
            if (_timerCreateNewSlowTime > CONSTANTSES.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewSlowTime = 0;
                CreateBonusSlowTime(CONSTANTSES.BONUS_SLOW_TIME_FIELD_VALUE);
            }

            if (_timerSlowTime > CONSTANTSES.MAX_TIME_ACTIVE_BONUS_SLOW_TIME)
                ManagerTimeScale(CONSTANTSES.DEFAULT_TIME_SCALE);

            _timerCreateNewSlowTime += Time.deltaTime;
            _timerSlowTime += Time.deltaTime;
            Debug.Log(_timerSlowTime);
        }

        public void CreateBonusSlowTime(int bonusFieldValue)
        {
            _timerCreateNewSlowTime = 0;
            CreateBonus(bonusFieldValue);
        }

        public void GetBonusSlowTime(int bonusFieldValue)
        {
            ManagerTimeScale(CONSTANTSES.TIME_SCALE_BONUS_SLOW_TIME);
            _timerCreateNewSlowTime = 0;
            _timerSlowTime = 0;
            CreateBonus(bonusFieldValue);
        }
    }
}
