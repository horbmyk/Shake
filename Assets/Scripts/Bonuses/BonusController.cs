using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class BonusController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;//private
        [SerializeField] public SnakeController SnakeController;//private

        private void OnEnable()
        {
            SnakeController.SnakeBodyGrowUpEvent += CreateBonus;
        }

        private void OnDisable()
        {
            SnakeController.SnakeBodyGrowUpEvent -= CreateBonus;
        }

        public void CreateBonus(int bonusFieldValue)
        {
            //int[,] _arrayValues = _fieldController.GetArrayValues();
            //List<Vector2Int> _tmpArrayValues = new List<Vector2Int>();

            //for (int i = 0; i < _arrayValues.GetLength(0); i++)
            //{
            //    for (int k = 0; k < _arrayValues.GetLength(1); k++)
            //    {
            //        if (_arrayValues[i, k] == bonusFieldValue)//Delete Old Bonus 
            //            _fieldController.WriteProgress(new Vector2Int(i, k), CONSTANTSES.FREE_FIELD_VALUE);

            //        if (_arrayValues[i, k] == 0)
            //            _tmpArrayValues.Add(new Vector2Int(i, k));
            //    }
            //}

            //_fieldController.WriteProgress(_tmpArrayValues[Random.Range(0, _tmpArrayValues.Count)], bonusFieldValue);
        }
    }
}
