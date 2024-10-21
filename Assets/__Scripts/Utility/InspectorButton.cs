using UnityEngine;
using UnityEngine.Events;

public class InspectorButton : MonoBehaviour
{
    public UnityEvent Event;

    public void RaiseEvent()
    {
        Event.Invoke();
    }
}
