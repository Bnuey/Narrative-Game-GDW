using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    public void ShowPauseMenu(bool value)
    {
        _menu.SetActive(value);
    }
}
