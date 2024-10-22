using SmartData.SmartBool;
using SmartData.SmartEvent;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] EventDispatcher _pauseEvent, _unPauseEvent;
    [SerializeField] BoolWriter _gameIsPaused;

    void PauseGame()
    {
        if (!_gameIsPaused.value)
        {
            _pauseEvent.Dispatch();
            _gameIsPaused.value = true;

            Time.timeScale = 0;
        }
        else
        {
            _unPauseEvent.Dispatch();
            _gameIsPaused.value = false;

            Time.timeScale = 1;
        }



    }
    private void OnEnable()
    {
        PlayerInput.PauseInput += PauseGame;
    }

    private void OnDisable()
    {
        PlayerInput.PauseInput -= PauseGame;
    }
}
