using UnityEngine;
using UnityEngine.UI;

namespace Shake
{
    public class CellTwoD : MonoBehaviour, ICell
    {
        [SerializeField] private Sprite _apple;
        [SerializeField] private Sprite _slowTime;
        [SerializeField] private Sprite _speedUp;

        public void SetColor(int indexColor)
        {
            GetComponent<Image>().sprite = null;
            GetComponent<Image>().color = Color.white;

            switch (indexColor)
            {
                case Constants.FREE_FIELD_VALUE:
                    GetComponent<Image>().color = Color.blue;
                    break;

                case Constants.SNAKE_ITEM_BODY_FIELD_VALUE:
                    GetComponent<Image>().color = Color.green;
                    break;

                case Constants.SNAKE_HEAD_FIELD_VALUE:
                    GetComponent<Image>().color = Color.red;
                    break;

                case Constants.BONUS_BODY_GROWUP_FIELD_VALUE:
                    GetComponent<Image>().sprite = _apple;
                    break;

                case Constants.BONUS_SLOW_TIME_FIELD_VALUE:
                    GetComponent<Image>().sprite = _slowTime;
                    break;

                case Constants.BONUS_SPEED_UP_FIELD_VALUE:
                    GetComponent<Image>().sprite = _speedUp;
                    break;
            }
        }
    }
}
