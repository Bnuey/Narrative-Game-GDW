using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextDialogue : ScriptableObject
{
    public List<string> Text;

    public AudioClips DialogueAudioClips;

    TextBox _textBox;
    public void ShowText()
    {
        _textBox = FindFirstObjectByType<TextBox>();
        _textBox.ShowTextBox(this);
    }
}
