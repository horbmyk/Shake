using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class BonusSlowTime : BonusBodyGrowUp
    {
        private void OnEnable()
        {
            SnakeController.SnakeSlowTimeEvent += CreateBonusSnakeSlowTime;
        }

        private void OnDisable()
        {
            SnakeController.SnakeSlowTimeEvent -= CreateBonusSnakeSlowTime;
        }

        public void CreateBonusSnakeSlowTime(int bonusFieldValue)
        {
            CreateBonus(bonusFieldValue);
        }
    }
}
