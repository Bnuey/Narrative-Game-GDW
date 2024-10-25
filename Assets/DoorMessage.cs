using System;
using UnityEngine;

public class DoorMessage : MonoBehaviour
{
    [SerializeField] TextDialogue _doorDialogue;

    [SerializeField] GameObject _lookAtPoint;

    public void ShowDoorText()
    {
        _doorDialogue.ShowText();
        if (_lookAtPoint == null)
            CharacterDialogue.LookAt?.Invoke(gameObject);
        else
            CharacterDialogue.LookAt?.Invoke(_lookAtPoint);
        
    }
}
