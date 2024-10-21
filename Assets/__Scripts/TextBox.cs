using DG.Tweening;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _box;

    [SerializeField] AudioClip _textBoxAppearAudioClip;

    bool _hideBox;

    public static Action<bool> Talking;

    public async void ShowTextBox(TextDialogue textBox)
    {
        transform.DOShakePosition(5, 3, 50, 90, false, false);
        _hideBox = false;

        _box.SetActive(true);

        SoundFXManager.Instance.PlayRandomPitchSoundFXClip(_textBoxAppearAudioClip, transform, 0.3f, .9f, 1.2f);

        Talking?.Invoke(true);

        for (int i = 0; i < textBox.Text.Length - 1; i++)
        {
            if (_text.text.Length % textBox.DialogueAudioClips.Frequency == 0)
            {

                float predictablePitch = 0;

                var currentChar = textBox.Text[i];

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

            string currentText = textBox.Text.Remove(i);
            _text.text = currentText;
            await Awaitable.WaitForSecondsAsync(0.02f);
        }
        
        
        _text.text = textBox.Text;

        Talking?.Invoke(false);

        _hideBox = true;
        await HideTextBox(textBox.ShowTime);
    }

    async Task HideTextBox(float time)
    {
        await Awaitable.WaitForSecondsAsync(time);

        if (!_hideBox) return;

        _box.SetActive(false);
        _text.text = "";

        _hideBox = false;

        

    }
}
