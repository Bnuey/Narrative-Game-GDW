using SmartData.SmartBool;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextDialogue : ScriptableObject
{
    public Character Character;

    public List<string> Text;

    TextBox _textBox;
    public bool SelectionBox;

    public TextDialogue[] _nextTextBoxs;

    public GameState SwitchToState;


    public void ShowText()
    {
        _textBox = FindFirstObjectByType<TextBox>();
        _textBox.ShowTextBox(this);
    }

}
