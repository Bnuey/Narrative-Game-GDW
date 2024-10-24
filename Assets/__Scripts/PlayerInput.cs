using SmartData.SmartEvent;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static Action<Vector2> MoveEvent;
    public static Action<Vector2> LookEvent;
    public static Action InteractEvent;

    public static Action PauseInput;
    public static Action JumpEvent;

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        LookEvent?.Invoke(context.ReadValue<Vector2>());
    }
    
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        InteractEvent?.Invoke();
        
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        PauseInput?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        JumpEvent?.Invoke();
    }

}
