using DG.Tweening;
using SmartData.SmartBool;
using System;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] BoolReader _playerHoldingKey;
    [SerializeField] GameObject _hinge;

    public void InteractedWith(RaycastHit hitinfo)
    {
        if (_playerHoldingKey.value)
            Open();
    }

    void Open()
    {
        _hinge.transform.DORotate(new Vector3(0, 110, 0), 0.5f);
        Key.DestroyKey?.Invoke();
    }

}
