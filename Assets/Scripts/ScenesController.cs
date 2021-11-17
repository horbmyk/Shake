using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shake
{
    public class ScenesController : MonoBehaviour
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
