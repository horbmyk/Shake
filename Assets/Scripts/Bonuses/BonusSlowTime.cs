using System.Collections.Generic;
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
            if (_timerCreateNewSlowTime > CONSTANTSES.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewSlowTime = 0;
                CreateBonusSlowTime(CONSTANTSES.BONUS_SLOW_TIME_FIELD_VALUE);
            }

            if (_timerSlowTime > CONSTANTSES.MAX_TIME_ACTIVE_BONUS_SLOW_TIME && _managerTimeScaleAvailable)
            {
                _managerTimeScaleAvailable = false;
                ManagerTimeScale(CONSTANTSES.DEFAULT_TIME_SCALE);
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
            ManagerTimeScale(CONSTANTSES.TIME_SCALE_BONUS_SLOW_TIME);
            _timerSlowTime = 0;
            ScoreController.Score += CONSTANTSES.BONUS_POINTS;
            CreateBonusSlowTime(bonusFieldValue);
        }
    }
}
