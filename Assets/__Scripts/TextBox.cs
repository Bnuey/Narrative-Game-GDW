using DG.Tweening;
using SmartData.SmartEvent;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _box;

    [SerializeField] AudioClip _textBoxAppearAudioClip;

    [SerializeField] EventDispatcher _npcTalkingEvent, _npcDoneTalking;

    int _currentLine;

    TextDialogue _currentTextBox;

    public async void ShowTextBox(TextDialogue textBox)
    {
        _currentTextBox = textBox;

        transform.DOShakePosition(5, 3, 50, 90, false, false);

        _box.SetActive(true);

        _npcTalkingEvent.Dispatch();

        SoundFXManager.Instance.PlayRandomPitchSoundFXClip(_textBoxAppearAudioClip, transform, 0.3f, .9f, 1.2f);

        for (int i = 0; i < textBox.Text[_currentLine].Length - 1; i++)
        {
            if (_text.text.Length % textBox.DialogueAudioClips.Frequency == 0)
            {

                float predictablePitch = 0;

                var currentLine = textBox.Text[_currentLine];
                var currentChar = currentLine[i];

                // Hash
                int hashCode = Mathf.Abs(currentChar.GetHashCode());

                // Pick Sound Clip Based On Hash
                int predictableIndex = hashCode % textBox.DialogueAudioClips.Clips.Count;
                var soundClip = textBox.DialogueAudioClips.Clips[predictableIndex];

                // Pick Pitch Based On Hash
                int minPitchInt = (int)(textBox.DialogueAudioClips.MinPitch * 100);
                int maxPitchInt = (int)(textBox.DialogueAudioClips.MaxPitch * 100);
                int pitchRangeInt = maxPitchInt - minPitchInt;

                if (pitchRangeInt != 0)
                {
                    int predictablePitchInt = (hashCode % pitchRangeInt) + minPitchInt;
                    predictablePitch = predictablePitchInt / 100f;
                }
                else
                {
                    predictablePitch = textBox.DialogueAudioClips.MinPitch;
                }



                SoundFXManager.Instance.PlaySoundFXClip(soundClip, transform, textBox.DialogueAudioClips.Volume, predictablePitch);
            }

            string currentText = textBox.Text[_currentLine].Remove(i);
            _text.text = currentText;
            await Awaitable.WaitForSecondsAsync(0.02f);
        }
        
        
        _text.text = textBox.Text[_currentLine];
    }

    public void HideTextBox()
    {
        _box.SetActive(false);
        _text.text = "";

        _currentTextBox = null;
        _currentLine = 0;
        _npcDoneTalking.Dispatch();
    }

    void ContinueText()
    {
        if (_currentLine >= _currentTextBox.Text.Count - 1)
        {
            HideTextBox();
        }
        else
        {
            _currentLine += 1;
            ShowTextBox(_currentTextBox);
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
