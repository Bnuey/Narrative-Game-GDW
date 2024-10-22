using System;
using UnityEngine;

public class CharacterDialogue : MonoBehaviour, IInteractable
{
    [SerializeField] TextDialogue _testDialogue;

    public static Action<GameObject> LookAt;
    [SerializeField] GameObject _lookAtPoint;
    public void InteractedWith(RaycastHit hitinfo)
    {
        _testDialogue.ShowText();
        if (_lookAtPoint == null) 
            LookAt?.Invoke(gameObject);
        else 
            LookAt?.Invoke(_lookAtPoint);
    }
}
