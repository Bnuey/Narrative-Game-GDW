using Cinemachine;
using UnityEngine;

public class ToggleMouseMovement : MonoBehaviour
{
    CinemachineInputProvider inputProvider;
    private void Awake()
    {
        inputProvider = GetComponent<CinemachineInputProvider>();
    }
    private void Enable()
    {
        inputProvider.enabled = true;
    }
    private void Disable()
    {
        inputProvider.enabled = false;
    }
}
