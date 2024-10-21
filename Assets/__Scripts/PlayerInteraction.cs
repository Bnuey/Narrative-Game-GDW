using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    Camera _cam;

    [SerializeField] float _interactSphere, _interactDistance;
    [SerializeField] LayerMask _layerMask;

    public static Action PlayerInteracted;
    public static Action<GameObject> PlayerGrabbed;
    public static Action ReleaseObject;

    private void Awake()
    {
        _cam = Camera.main;
    }

    public void Interact()
    {
        if (Physics.SphereCast(_cam.transform.position, _interactSphere, _cam.transform.forward, out RaycastHit hitinfo, _interactDistance, _layerMask))
        {
            if (hitinfo.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.InteractedWith(hitinfo);
            }
        }
        else
        {
            ReleaseObject?.Invoke();
        }
    }

    private void OnEnable()
    {
        PlayerInput.InteractEvent += Interact;
    }

    private void OnDisable()
    {
        PlayerInput.InteractEvent -= Interact;
    }
}
