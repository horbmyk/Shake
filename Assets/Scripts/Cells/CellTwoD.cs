using UnityEngine;
using UnityEngine.UI;

namespace Shake
{
    public class CellTwoD : MonoBehaviour, ICell
    {
        //Delete Magic number
        public void SetColor(int indexColor)
        {
            switch (indexColor)
            {
                case 0:
                    GetComponent<Image>().color = new Color(0, 0, 1);
                    break;

                case 1:
                    GetComponent<Image>().color = new Color(0, 1, 0);
                    break;

                case 2:
                    GetComponent<Image>().color = new Color(1, 0, 0);
                    break;

                case 3:
                    GetComponent<Image>().color = new Color(1, 1, 0);
                    break;

                case 4:
                    GetComponent<Image>().color = new Color(0, 1, 1);
                    break;

            }
        }
    }
}
