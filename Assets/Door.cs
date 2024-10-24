using DG.Tweening;
using SmartData.SmartBool;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] BoolReader _playerHoldingKey;
    [SerializeField] GameObject _hinge;
    [SerializeField] UnityEvent _doorOpen;

    [SerializeField] AudioClip _doorOpenSound;

    public void InteractedWith(RaycastHit hitinfo)
    {
        if (_playerHoldingKey.value)
            Open();
    }

    void Open()
    {
        SoundFXManager.Instance.PlaySoundFXClip(_doorOpenSound, transform, 0.3f, 1);
        _hinge.transform.DOLocalRotate(new Vector3(0, 110, 0), 0.5f);
        Key.DestroyKey?.Invoke();
        _doorOpen.Invoke();
    }

}
