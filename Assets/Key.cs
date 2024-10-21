using System;
using UnityEngine;

[RequireComponent(typeof(Grabable))]
public class Key : MonoBehaviour
{
    public static Action DestroyKey;
    public void KillKey()
    {
        Destroy(gameObject);
    }
}
