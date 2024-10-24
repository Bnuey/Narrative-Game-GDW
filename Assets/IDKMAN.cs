using SmartData.SmartEvent;
using UnityEngine;

public class IDKMAN : MonoBehaviour
{
    [SerializeField] EventDispatcher _event;

    public void RunEvent()
    {
        _event.Dispatch();
    }
}
