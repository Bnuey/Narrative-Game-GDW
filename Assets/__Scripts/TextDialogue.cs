using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextDialogue : ScriptableObject
{
    public Character Character;

    public List<string> Text;

    TextBox _textBox;

    public TextDialogue _nextTextBox;

    public void ShowText()
    {
        _textBox = FindFirstObjectByType<TextBox>();
        _textBox.ShowTextBox(this);
    }
}
