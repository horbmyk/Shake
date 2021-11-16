using UnityEngine;

namespace Shake
{
    public class FieldController : MonoBehaviour
    {
        [SerializeField] private GameProgress _gameProgress;
        [SerializeField] private GameObject _prefabCell;
        private ICell[,] _tmpGameField;
        private const int SIZE_FIELD = 2;

        private void InitializationArrayGameFieldValues()
        {
            _gameProgress.ArrayGameFieldValues = new int[SIZE_FIELD, SIZE_FIELD];
        }

        private void InitializationGameFieldCells()
        {
            _tmpGameField = new ICell[SIZE_FIELD, SIZE_FIELD];

            for (int i = 0; i < SIZE_FIELD; i++)
            {
                for (int k = 0; k < SIZE_FIELD; k++)
                {
                    GameObject cell = Instantiate(_prefabCell, transform);
                    _tmpGameField[i, k] = cell.GetComponent<ICell>();
                }
            }
        }

        private void RefreshColorGameFieldCells()
        {
            for (int i = 0; i < SIZE_FIELD; i++)
                for (int k = 0; k < SIZE_FIELD; k++)
                    _tmpGameField[i, k].SetColor(_gameProgress.ArrayGameFieldValues[i, k]);
        }

        private void Awake()
        {
            InitializationGameFieldCells();
            InitializationArrayGameFieldValues();
        }

        private void Start()
        {
            RefreshColorGameFieldCells();
        }
    }
}
