using System;
using UnityEngine;

public class CharacterDialogue : MonoBehaviour, IInteractable
{
    [SerializeField] TextDialogue[] _firstDialogueBoxs;

    public static Action<GameObject> LookAt;
    [SerializeField] GameObject _lookAtPoint;

    [SerializeField] bool _checkForRequirements;
    [SerializeField] int _checkFor;
    

    public void InteractedWith(RaycastHit hitinfo)
    {
        if (_checkForRequirements)
            _firstDialogueBoxs[GameManager.Instance.DecisionNumbers[_checkFor]].ShowText();
        else
            _firstDialogueBoxs[0].ShowText();

        if (_lookAtPoint == null) 
            LookAt?.Invoke(gameObject);
        else 
            LookAt?.Invoke(_lookAtPoint);
    }
}
