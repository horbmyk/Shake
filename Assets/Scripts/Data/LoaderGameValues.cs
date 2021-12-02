using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shake
{
    public class LoaderGameValues : MonoBehaviour
    {
        [SerializeField] private GameValuesScriptableObject _gameValuesScriptableObject;

        public int GetBonusScorePoints() => _gameValuesScriptableObject.BonusScorePoints;
        public int GetSnakeMovementSpeed() => _gameValuesScriptableObject.SnakeMovementSpeed;

    }
}
