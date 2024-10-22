using System;
using SmartData.SmartEvent;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] EventDispatcher _hideCursor, _showCursor;

	[SerializeField] TextBox _textBox;

	int _currentFramerate;

	[Header("Textboxes")]
	[SerializeField] TextDialogue _testDialogue;
	void Start()
	{
		_hideCursor.Dispatch();
	}


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			Application.targetFrameRate = 1000;
		}
		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			Application.targetFrameRate = 2;
		}
		if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			Application.targetFrameRate = 15;
		}
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Application.targetFrameRate = 30;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Application.targetFrameRate = 60;
        }
    }
}
