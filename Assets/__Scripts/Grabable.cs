using SmartData.SmartBool;
using System;
using UnityEngine;

public class Grabable : MonoBehaviour, IInteractable
{
    public static Action<Grabable> ItemGrabbed;
    public void InteractedWith(RaycastHit hitinfo)
    {
        ItemGrabbed?.Invoke(this);
    }
}
