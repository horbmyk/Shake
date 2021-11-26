using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _pause;

    private void Awake()
    {
        _pause.SetActive(false);
    }
    public void Pause()
    {
        _pause.SetActive(true);
    }

    public void Continue()
    {
        _pause.SetActive(false);
    }

}
