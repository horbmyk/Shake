using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class BonusController : MonoBehaviour
    {
        [SerializeField] private FieldController _fieldController;
        private const int BONUS_FIELD_VALUE = 3;
        private const int FREE_FIELD_VALUE = 0;

        public void CreateBonus()
        {
            int[,] _arrayValues = _fieldController.GetArrayValues();
            List<Vector2Int> _tmpArrayValues = new List<Vector2Int>();

            for (int i = 0; i < _arrayValues.GetLength(0); i++)
            {
                for (int k = 0; k < _arrayValues.GetLength(1); k++)
                {
                    if (_arrayValues[i, k] == BONUS_FIELD_VALUE)//Delete Old Bonus 
                        _fieldController.WriteProgress(new Vector2Int(i, k), FREE_FIELD_VALUE);

                    if (_arrayValues[i, k] == 0)
                        _tmpArrayValues.Add(new Vector2Int(i, k));
                }
            }

            _fieldController.WriteProgress(_tmpArrayValues[Random.Range(0, _tmpArrayValues.Count)], BONUS_FIELD_VALUE);
        }
    }
}
