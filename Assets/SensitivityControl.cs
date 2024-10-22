using Cinemachine;
using SmartData.SmartFloat;
using UnityEngine;

public class SensitivityControl : MonoBehaviour
{
    [SerializeField] FloatReader _sensitivity;
    CinemachinePOV _vCam;

    void Awake()
    {
        _vCam = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
    }

    public void UpdateCameraSensitivity()
    {
        _vCam.m_HorizontalAxis.m_MaxSpeed = _sensitivity.value;
        _vCam.m_VerticalAxis.m_MaxSpeed = _sensitivity.value;
    }
}
