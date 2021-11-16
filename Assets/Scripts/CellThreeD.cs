using UnityEngine;
using UnityEngine.UI;

namespace Shake
{
    public class CellThreeD : MonoBehaviour, ICell
    {
        public void SetColor(int indexColor)
        {
            switch (indexColor)
            {
                case 0:
                    GetComponent<Image>().color = new Color(0, 0, 0);//
                    break;

                case 1:
                    GetComponent<Image>().color = new Color(1, 0, 0);//
                    break;


            }
        }
    }
}
