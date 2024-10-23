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

    public TextDialogue _nextTextBox;

    public BoolWriter Option1Bool, Option2Bool, Option3Bool;

    public void ShowText()
    {
        _textBox = FindFirstObjectByType<TextBox>();
        _textBox.ShowTextBox(this);
    }

    public void SetBool(int num)
    {
        switch (num)
        {
            case 0:
                Option1Bool.value = true;
                break;
            case 1:
                Option2Bool.value = true;
                break;
            case 2:
                Option3Bool.value = true;
                break;

        }
    }

}
