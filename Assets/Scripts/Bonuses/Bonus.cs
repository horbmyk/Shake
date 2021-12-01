using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] public SnakeController SnakeController;
        [SerializeField] public SoundController SoundController;
        [SerializeField] public ScoreController ScoreController;
        [SerializeField] private FieldController _fieldController;

        public IEnumerator CreateBonus(int bonusFieldValue)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            int[,] arrayValues = _fieldController.GetArrayValues();
            List<Vector2Int> tmpArrayValues = new List<Vector2Int>();

            for (int i = 0; i < arrayValues.GetLength(0); i++)
            {
                for (int k = 0; k < arrayValues.GetLength(1); k++)
                {
                    if (arrayValues[i, k] == bonusFieldValue)//Delete Old Bonus 
                        _fieldController.WriteProgress(new Vector2Int(i, k), Constants.FREE_FIELD_VALUE);

                    if (arrayValues[i, k] == 0)
                        tmpArrayValues.Add(new Vector2Int(i, k));
                }
            }

            _fieldController.WriteProgress(tmpArrayValues[Random.Range(0, tmpArrayValues.Count - 1)], bonusFieldValue);
        }

        public void ManagerTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}
