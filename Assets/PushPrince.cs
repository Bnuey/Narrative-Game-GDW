using UnityEngine;

public class PushPrince : MonoBehaviour
{
    [SerializeField] float _pushForce;
    Rigidbody _rb;
    void Awake() => _rb = GetComponent<Rigidbody>();
    public void PushThePrince(GameState state)
    {
        if (state != GameState.Option15) return;

        _rb.AddForce(-Vector3.right * _pushForce, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        GameManager.OnAfterStateChange += PushThePrince;
    }

    private void OnDisable()
    {
        GameManager.OnAfterStateChange -= PushThePrince;
    }


}
