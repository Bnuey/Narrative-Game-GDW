using System;
using SmartData.SmartEvent;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] EventDispatcher _hideCursor, _showCursor;

	[SerializeField] TextBox _textBox;

	[Header("Textboxes")]
	[SerializeField] TextDialogue _testDialogue;
	void Start()
	{
		_hideCursor.Dispatch();
	}

}
