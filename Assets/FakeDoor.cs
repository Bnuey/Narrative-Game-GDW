using UnityEngine;

public class FakeDoor : MonoBehaviour, IInteractable
{
    Rigidbody _rb;

    [SerializeField] float _pushForce;

    void Awake() => _rb = GetComponent<Rigidbody>();
    public void InteractedWith(RaycastHit hitinfo)
    {
        _rb.AddForce(-Vector3.forward * _pushForce, ForceMode.Impulse);
    }
}
