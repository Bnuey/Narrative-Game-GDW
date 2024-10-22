using System;
using UnityEngine;

public class PlayerContinueDialogue : MonoBehaviour
{
    public static Action ContinueTalking;

    public void OnInteract()
    {
        ContinueTalking?.Invoke();
    }


    private void OnEnable()
    {
        PlayerInput.InteractEvent += OnInteract;
    }
    private void OnDisable()
    {
        PlayerInput.InteractEvent -= OnInteract;
    }
}
