using DG.Tweening;
using SmartData.SmartBool;
using SmartData.SmartEvent;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Image _box;
    [SerializeField] Image _nameBox;

    [SerializeField] TextMeshProUGUI _nameText;

    [SerializeField] AudioClip _textBoxAppearAudioClip;

    [SerializeField] BoolWriter _npcTalking;

    [Header("Events")]
    [SerializeField] EventDispatcher _npcTalkingEvent;
    [SerializeField] EventDispatcher _npcDoneTalking;
    [SerializeField] EventDispatcher _hideCursor;
    [SerializeField] EventDispatcher _showCursor;

    [Header("Boxes")]
    [SerializeField] GameObject _selectionBox;
    [SerializeField] GameObject _defaultBox;

    [Header("OptionBoxes")]
    [SerializeField] TextMeshProUGUI _option1;
    [SerializeField] TextMeshProUGUI _option2;
    [SerializeField] TextMeshProUGUI _option3;

    int _currentLine;

    TextDialogue _currentTextBox;

    public async void ShowTextBox(TextDialogue textBox)
    {
        GameManager.Instance.ClearObjectiveText();
        if (textBox.SelectionBox)
        {
            _selectionBox.SetActive(true);
            _defaultBox.SetActive(false);

            _currentTextBox = textBox;

            _option1.text = textBox.Text[0];
            _option2.text = textBox.Text[1];
            _option3.text = textBox.Text[2];

            _box.color = textBox.Character.Color;

            _showCursor.Dispatch();

            return;
        }
        else
        {
            _selectionBox.SetActive(false);
            _defaultBox.SetActive(true);
            _hideCursor.Dispatch();
        }



        _currentTextBox = textBox;

        _nameText.text = textBox.Character.Name;
        _box.color = textBox.Character.Color;
        _nameBox.color = textBox.Character.Color;

        transform.DOShakePosition(30, 3, 50, 90, false, false);

        _box.gameObject.SetActive(true);

        _npcTalkingEvent.Dispatch();
        _npcTalking.value = true;

        SoundFXManager.Instance.PlayRandomPitchSoundFXClip(_textBoxAppearAudioClip, transform, 0.3f, .9f, 1.2f);

        for (int i = 0; i < textBox.Text[_currentLine].Length - 1; i++)
        {
            if (_text.text.Length % textBox.Character.DialogueAudioClips.Frequency == 0)
            {

                float predictablePitch = 0;

                var currentLine = textBox.Text[_currentLine];
                var currentChar = currentLine[i];

                // Hash
                int hashCode = Mathf.Abs(currentChar.GetHashCode());

                // Pick Sound Clip Based On Hash
                int predictableIndex = hashCode % textBox.Character.DialogueAudioClips.Clips.Count;
                var soundClip = textBox.Character.DialogueAudioClips.Clips[predictableIndex];

                // Pick Pitch Based On Hash
                int minPitchInt = (int)(textBox.Character.DialogueAudioClips.MinPitch * 100);
                int maxPitchInt = (int)(textBox.Character.DialogueAudioClips.MaxPitch * 100);
                int pitchRangeInt = maxPitchInt - minPitchInt;

                if (pitchRangeInt != 0)
                {
                    int predictablePitchInt = (hashCode % pitchRangeInt) + minPitchInt;
                    predictablePitch = predictablePitchInt / 100f;
                }
                else
                {
                    predictablePitch = textBox.Character.DialogueAudioClips.MinPitch;
                }



                SoundFXManager.Instance.PlaySoundFXClip(soundClip, transform, textBox.Character.DialogueAudioClips.Volume, predictablePitch);
            }

            string currentText = textBox.Text[_currentLine].Remove(i);
            _text.text = currentText;
            await Awaitable.WaitForSecondsAsync(0.02f);
        }

        _text.text = textBox.Text[_currentLine];
        _npcTalking.value = false;

    }

    public void HideTextBox()
    {
        ResetTextBox();

        if (_currentTextBox.SwitchToState != GameState.Default)
            GameManager.Instance.ChangeState(_currentTextBox.SwitchToState);

        if (!String.IsNullOrEmpty(_currentTextBox.ObjectiveAfterClear))
        {
            GameManager.Instance.SetObjectiveText(_currentTextBox.ObjectiveAfterClear);
        }

        _box.gameObject.SetActive(false);
        _currentTextBox = null;
        _npcDoneTalking.Dispatch();
    }

    void ResetTextBox()
    {
        _text.text = "";
        _currentLine = 0;
    }

    void ContinueText()
    {
        if (_npcTalking.value) return;

        if (_currentLine >= _currentTextBox.Text.Count - 1)
        {
            if (_currentTextBox._nextTextBoxs.Length != 0)
            {
                ResetTextBox();
                ShowTextBox(_currentTextBox._nextTextBoxs[0]);
            }
            else
                HideTextBox();
        }
        else
        {
            _currentLine += 1;
            ShowTextBox(_currentTextBox);
        }

    }

    public void ClickOptionButton(int num)
    {
        switch (GameManager.Instance.CurrentState)
        {
            case (GameState.TalkToMaid):
                if (num == 0)
                    GameManager.Instance.ChangeState(GameState.Option1);
                else if (num == 1)
                    GameManager.Instance.ChangeState(GameState.Option2);
                else if (num == 2)
                    GameManager.Instance.ChangeState(GameState.Option3);
                break;

            case (GameState.FoundMeds):
                if (num == 0)
                    GameManager.Instance.ChangeState(GameState.Option4);
                else if (num == 1)
                    GameManager.Instance.ChangeState(GameState.TookMeds);
                else if (num == 2)
                    GameManager.Instance.ChangeState(GameState.TookMeds);
                break;


            case (GameState.GiveKey):
                if (num == 0)
                    GameManager.Instance.ChangeState(GameState.Option7);
                else if (num == 1)
                    GameManager.Instance.ChangeState(GameState.Option8);
                else if (num == 2)
                    GameManager.Instance.ChangeState(GameState.Option9);
                break;

            case GameState.Option7:
                if (num == 0)
                    GameManager.Instance.ChangeState(GameState.Option10);
                else if (num == 1)
                    GameManager.Instance.ChangeState(GameState.Option11);
                else if (num == 2)
                    GameManager.Instance.ChangeState(GameState.Option12);
                break;

            case GameState.Option9:
                if (num == 0)
                    GameManager.Instance.ChangeState(GameState.Option13);
                else if (num == 1)
                    GameManager.Instance.ChangeState(GameState.Option13);
                else if (num == 2)
                    GameManager.Instance.ChangeState(GameState.Option15);
                break;
        }



        
    }


    private void OnEnable()
    {
        PlayerContinueDialogue.ContinueTalking += ContinueText;
    }

    private void OnDisable()
    {
        PlayerContinueDialogue.ContinueTalking -= ContinueText;
    }
}
