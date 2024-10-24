using SmartData.SmartBool;
using UnityEngine;
using UnityEngine.Events;

public class ButlerLogic : MonoBehaviour
{
    [SerializeField] CharacterDialogue _firstDialogue, _spoonDialogue;
    [SerializeField] BoolReader _holdingSpoon;

    [SerializeField] TextDialogue _afterDinner;
    public void SpoonGrabbed()
    {
        if (!_holdingSpoon.value) return;


        Destroy(_firstDialogue);
        _spoonDialogue.enabled = true;
    }

    public void AfterDinner()
    {
        Destroy(_spoonDialogue);
        _afterDinner.ShowText();
    }
}
