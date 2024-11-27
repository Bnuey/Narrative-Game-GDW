using UnityEngine;
using UnityEngine.Rendering;

public class TurnLightOnOff : MonoBehaviour
{
    Light _light;
    LensFlareComponentSRP _lensFlare;

    private void Awake()
    {
        _light = GetComponent<Light>();
        _lensFlare = GetComponent<LensFlareComponentSRP>();
    }

    void ChangeLightState(bool currentState)
    {
        if (!currentState)
        {
            _light.enabled = false;
            _lensFlare.enabled = false;
        }
        else
        {
            _light.enabled = true;
            _lensFlare.enabled = true;
        }
    }

    private void OnEnable()
    {
        GameManager.TextureStateChanged += ChangeLightState;
    }

    private void OnDisable()
    {
        GameManager.TextureStateChanged -= ChangeLightState;
    }
}
