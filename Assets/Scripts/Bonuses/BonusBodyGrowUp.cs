using UnityEngine;

namespace Shake
{
    public class BonusBodyGrowUp : Bonus
    {
        private float _timerCreateNewBodyGrowUp;

        private void OnEnable()
        {
            SnakeController.BodyGrowUpEvent += GetBonus;
        }

        private void OnDisable()
        {
            SnakeController.BodyGrowUpEvent -= GetBonus;
        }

        private void Update()
        {
            if (_timerCreateNewBodyGrowUp > Constants.MAX_TIME_CREATE_NEW_BONUS)
            {
                _timerCreateNewBodyGrowUp = 0;
                CreateBonusGrowUp(Constants.BONUS_BODY_GROWUP_FIELD_VALUE);
            }

            _timerCreateNewBodyGrowUp += Time.deltaTime;
        }

        public void CreateBonusGrowUp(int bonusFieldValue)
        {
            _timerCreateNewBodyGrowUp = 0;
            StartCoroutine(CreateBonus(bonusFieldValue));
        }

        public void GetBonus(int bonusFieldValue)
        {
            _timerCreateNewBodyGrowUp = 0;
            StartCoroutine(CreateBonus(bonusFieldValue));
            PlaySoundFood();
            AddScore();
        }
    }
}
