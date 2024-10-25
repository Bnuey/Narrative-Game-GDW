using System;
using System.Collections.Generic;
using SmartData.SmartEvent;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameState CurrentState;

    [SerializeField] GameState _startingState;

    public static Action<GameState> OnBeforeStateChange;
    public static Action<GameState> OnAfterStateChange;

    [SerializeField] TextDialogue _option1, _option2, _option3;
    [SerializeField] TextDialogue _option4, _option5, _option6;
    [SerializeField] TextDialogue _option7, _option8, _option9;
    [SerializeField] TextDialogue _option10, _option11, _option12;
    [SerializeField] TextDialogue _option13, _option14, _option15;
    [SerializeField] TextDialogue _foundMeds;

    [SerializeField] Animator _dinnerFadeAnim;
    [SerializeField] TextDialogue _afterDinner;

    [SerializeField] TextBox _textBox;

    [SerializeField] EventDispatcher _afterDinnerEvent;
    [SerializeField] AudioClip _takeMeds;

    [SerializeField] EndScreen _endScreen;
    [SerializeField] EndScreenText _goodEnding1, _goodEnding2, _neutralEnding, _badEnding1, _badEnding2;

    [SerializeField] TextMeshProUGUI _objectiveText;

    [SerializeField] TextDialogue _findPillsEarly;

    private void Start()
    {
        ChangeState(_startingState);
    }

    public async void ChangeState(GameState newState)
    {
        await Awaitable.WaitForSecondsAsync(0.1f);
        CurrentState = newState;

        OnBeforeStateChange?.Invoke(newState);

        switch (newState)
        {
            case (GameState.TalkToMaid):
                _objectiveText.text = "Talk To Maid";
                break;

            case (GameState.Option1):
                _option1.ShowText();
                break;

            case (GameState.Option2):
                _option2.ShowText();
                break;

            case (GameState.Option3):
                _option3.ShowText();
                break;

            case (GameState.Option4):
                _option4.ShowText();
                break;

            case (GameState.Option7):
                _textBox.HideTextBox();
                _option7.ShowText();
                break;

            case (GameState.Option8):
                _textBox.HideTextBox();
                _option8.ShowText();
                break;

            case (GameState.Option9):
                _textBox.HideTextBox();
                _option9.ShowText();
                break;

            case (GameState.Option10):
                _option10.ShowText();
                ChangeState(GameState.GoToBed);
                break;

            case (GameState.Option11):
                _option11.ShowText();
                break;

            case (GameState.Option12):
                _option12.ShowText();
                ChangeState(GameState.GoToBed);
                break;

            case GameState.Option13:
                break;

            case GameState.Option14:
                break;

            case GameState.Option15:
                break;

            case (GameState.Dinner):
                _dinnerFadeAnim.SetTrigger("FadeInOut");
                break;

            case (GameState.AfterDinner):
                _afterDinner.ShowText();
                _afterDinnerEvent.Dispatch();
                break;

            case (GameState.TookMeds):
                _textBox.HideTextBox();
                SoundFXManager.Instance.PlaySoundFXClip(_takeMeds, transform, 0.5f, 1);
                await Awaitable.WaitForSecondsAsync(1.5f);
                ChangeState(GameState.Dinner);
                break;

            case GameState.FallSleep:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;

            case GameState.FoundMeds:
                _foundMeds.ShowText();
                break;

            case GameState.GoodEnding1:
                _endScreen.ShowEndScreen(_goodEnding1);
                break;

            case GameState.GoodEnding2:
                _endScreen.ShowEndScreen(_goodEnding2);
                break;

            case GameState.NeutralEnding:
                _endScreen.ShowEndScreen(_neutralEnding);
                break;

            case GameState.BadEnding1:
                _endScreen.ShowEndScreen(_badEnding1);
                break;

            case GameState.BadEnding2:
                _endScreen.ShowEndScreen(_badEnding2);
                break;

            case GameState.FindMedsEarly:
                _findPillsEarly.ShowText();
                break;
        }

        OnAfterStateChange?.Invoke(newState);

        Debug.Log("New Gamestate: " + newState);
    }

    public void ClearObjectiveText()
    {
        _objectiveText.text = "";

    }

    public void SetObjectiveText(string text)
    {
        _objectiveText.text = text;
    }

    public void HideTextBox()
    {
        _textBox.HideTextBox();
    }
}

public enum GameState
{
    Default = 0,
    TalkToMaid = 1,
    Option1 = 2,
    Option2 = 3,
    Option3 = 4,

    FindSpoon = 5,
    FoundSpoon = 6,

    FindMeds = 7,
    FoundMeds = 8,
    FindMedsEarly = 9,

    Dinner = 10,

    AfterDinner = 11,
    GiveKey = 12,

    Option4 = 13,
    Option5 = 14,
    Option6 = 15,
    Option7 = 16,
    Option8 = 17,
    Option9 = 18,
    Option10 = 19,
    Option11 = 20,
    Option12 = 21,

    TookMeds = 22,
    GoToBed = 23,

    Option13 = 24,
    Option14 = 25,
    Option15 = 26,

    FallSleep = 27,

    GoodEnding1 = 28,
    GoodEnding2 = 29,

    NeutralEnding = 30,

    BadEnding1 = 31,
    BadEnding2 = 32,

}
