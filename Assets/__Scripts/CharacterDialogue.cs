using UnityEngine;

public class CharacterDialogue : MonoBehaviour, IInteractable
{
    [SerializeField] TextDialogue _testDialogue;
    public void InteractedWith(RaycastHit hitinfo)
    {
        _testDialogue.ShowText();
    }
}
