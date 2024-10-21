using UnityEngine;

[CreateAssetMenu]
public class TextDialogue : ScriptableObject
{
    public string Text;
    public float ShowTime = 1;

    public AudioClips DialogueAudioClips;

    TextBox _textBox;
    public void ShowText()
    {
        _textBox = FindFirstObjectByType<TextBox>();
        _textBox.ShowTextBox(this);
    }
}
