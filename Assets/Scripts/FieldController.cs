using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shake
{
    public class FieldController : MonoBehaviour
    {
        [SerializeField] private GameProgress _gameProgress;
        [SerializeField] private GameObject _prefabCell;
        private ICell[,] _tmpGameField;
        private const int SIZE_FIELD = 10;
        private Vector2Int _snakeHead;
        private List<Vector2Int> _snakeBody;

        private void Awake()
        {
            InitializationGameField();
            InitializationArrayGameFieldValues();
        }
        private void Start()
        {
            LoadProgress();
            RefreshColorGameFieldCells();
        }

        private void InitializationArrayGameFieldValues()
        {
            _gameProgress.ArrayGameFieldValues = new int[SIZE_FIELD, SIZE_FIELD];
        }

        private void InitializationGameField()
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

        public void RefreshColorGameFieldCells()
        {
            for (int i = 0; i < SIZE_FIELD; i++)
                for (int k = 0; k < SIZE_FIELD; k++)
                    _tmpGameField[i, k].SetColor(_gameProgress.ArrayGameFieldValues[i, k]);
        }

        private void SaveProgress()
        {
            File.WriteAllText(Application.streamingAssetsPath + "/GameProgress.json", JsonConvert.SerializeObject(_gameProgress));
        }

        private void LoadProgress()
        {
            _gameProgress = JsonConvert.DeserializeObject<GameProgress>(File.ReadAllText(Application.streamingAssetsPath + "/GameProgress.json"));
        }

        public void WriteProgress(List<Vector2Int> dataarray, int value)
        {
            for (int i = 0; i < dataarray.Count; i++)
                _gameProgress.ArrayGameFieldValues[dataarray[i].x, dataarray[i].y] = value;

            RefreshColorGameFieldCells();
            SaveProgress();
        }
        public void WriteProgress(Vector2Int data, int value)
        {
            _gameProgress.ArrayGameFieldValues[data.x, data.y] = value;
            RefreshColorGameFieldCells();
            SaveProgress();
        }
    }
}
