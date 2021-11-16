using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shake
{
    public class ScenesControler : MonoBehaviour
    {
        public void LoadSceneTwoD()
        {
            SceneManager.LoadScene("ShakeTwoD");
        }
        public void LoadSceneThreeD()
        {
            SceneManager.LoadScene("ShakeThreeD");
        }
    }
}
