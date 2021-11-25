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
            SnakeController.SnakeSlowTimeEvent += CreateNewBonusSnakeSlowTime;
        }

        private void OnDisable()
        {
            SnakeController.SnakeSlowTimeEvent -= CreateNewBonusSnakeSlowTime;
        }

        private void Update()
        {
            if (_timerCreateNewSlowTime > CONSTANTSES.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewSlowTime = 0;
                CreateBonusSnakeSlowTime(CONSTANTSES.BONUS_SLOW_TIME_FIELD_VALUE);
            }

            if (_timerSlowTime > CONSTANTSES.MAX_TIME_ACTIVE_BONUS_SLOW_TIME)
                Time.timeScale = 1;

            _timerCreateNewSlowTime += Time.deltaTime;
            _timerSlowTime += Time.deltaTime;
        }

        public void CreateBonusSnakeSlowTime(int bonusFieldValue)
        {
            _timerCreateNewSlowTime = 0;
            CreateBonus(bonusFieldValue);
        }

        public void CreateNewBonusSnakeSlowTime(int bonusFieldValue)
        {
            Time.timeScale = 0.3f;
            _timerCreateNewSlowTime = 0;
            _timerSlowTime = 0;
            CreateBonus(bonusFieldValue);
        }
    }
}
