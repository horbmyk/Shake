using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class BonusBodyGrowUp : Bonus
    {
        private float _timerCreateNewBodyGrowUp;

        private void OnEnable()
        {
            SnakeController.BodyGrowUpEvent += CreateBonusGrowUp;
        }

        private void OnDisable()
        {
            SnakeController.BodyGrowUpEvent -= CreateBonusGrowUp;
        }

        private void Update()
        {
            if (_timerCreateNewBodyGrowUp > CONSTANTSES.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewBodyGrowUp = 0;
                CreateBonusGrowUp(CONSTANTSES.BONUS_BODY_GROWUP_FIELD_VALUE);
            }

            _timerCreateNewBodyGrowUp += Time.deltaTime;
        }

        public void CreateBonusGrowUp(int bonusFieldValue)
        {
            _timerCreateNewBodyGrowUp = 0;
            CreateBonus(bonusFieldValue);
        }
    }
}
