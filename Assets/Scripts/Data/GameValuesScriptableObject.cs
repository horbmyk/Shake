using UnityEngine;

namespace Shake
{
    [CreateAssetMenu(fileName = "GameValues", menuName = "ScriptableObjects/GameValuesScriptableObject", order = 1)]
    public class GameValuesScriptableObject : ScriptableObject
    {
        [Range(1, 4)] public int SnakeMovementSpeed;
        [Range(1, 3)] public int BonusScorePoints;
    }
}