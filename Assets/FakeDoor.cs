using UnityEngine;

public class FakeDoor : MonoBehaviour, IInteractable
{
    Rigidbody _rb;

    [SerializeField] float _pushForce;

    [SerializeField] Vector3 _pushDirection;

    void Awake() => _rb = GetComponent<Rigidbody>();
    public void InteractedWith(RaycastHit hitinfo)
    {
        _rb.AddForce(_pushDirection * _pushForce, ForceMode.Impulse);
    }
}
