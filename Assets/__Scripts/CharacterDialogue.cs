using System;
using UnityEngine;

public class CharacterDialogue : MonoBehaviour, IInteractable
{
    public GameState[] Gamestate;

    public TextDialogue[] _firstDialogueBoxs;

    public static Action<GameObject> LookAt;
    [SerializeField] GameObject _lookAtPoint;

    public void InteractedWith(RaycastHit hitinfo)
    {
        bool cont = false;

        foreach (GameState state in Gamestate)
        {
            if (state == GameManager.Instance.CurrentState)
            {
                cont = true;
            }
        }

        if (!cont) return;

        _firstDialogueBoxs[0].ShowText();

        if (_lookAtPoint == null) 
            LookAt?.Invoke(gameObject);
        else 
            LookAt?.Invoke(_lookAtPoint);
    }
}
