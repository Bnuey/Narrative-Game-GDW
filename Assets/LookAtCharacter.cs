using Cinemachine;
using UnityEngine;

public class LookAtCharacter : MonoBehaviour
{
    CinemachineVirtualCamera _vCam;

    void Awake() => _vCam = GetComponent<CinemachineVirtualCamera>();

    void LookAt(GameObject objectToLookAt)
    {
        _vCam.LookAt = objectToLookAt.transform;
    }

    public void StopLooking()
    {
        _vCam.LookAt = null;
    }

    private void OnEnable()
    {
        CharacterDialogue.LookAt += LookAt;
    }

    private void OnDisable()
    {
        CharacterDialogue.LookAt -= LookAt;
    }
}
