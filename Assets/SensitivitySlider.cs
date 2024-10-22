using SmartData.SmartFloat;
using UnityEngine;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] FloatWriter _sensitivity;

    public void UpdateSensitivity(float sens)
    {
        _sensitivity.value = sens;
    }
}
