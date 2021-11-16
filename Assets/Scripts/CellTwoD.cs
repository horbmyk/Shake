using UnityEngine;
using UnityEngine.UI;

namespace Shake
{
    public class CellTwoD : MonoBehaviour, ICell
    {
        public void SetColor(int indexColor)
        {
            switch (indexColor)
            {
                case 0:
                    GetComponent<Image>().color = new Color(0, 1, 0);
                    break;

                case 1:
                    GetComponent<Image>().color = new Color(0, 0, 1);
                    break;
            }
        }
    }
}
