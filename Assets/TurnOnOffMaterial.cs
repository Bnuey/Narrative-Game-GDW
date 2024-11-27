using UnityEngine;

public class TurnOnOffMaterial : MonoBehaviour
{
    [SerializeField] Material[] _materials;

    MeshRenderer _mr;

    private void Awake() => _mr = GetComponent<MeshRenderer>();
    void ChangeTextureState(bool currentState)
    {
        if (currentState)
            _mr.material = _materials[0];
        else
            _mr.material = _materials[1];
    }

    private void OnEnable()
    {
        GameManager.TextureStateChanged += ChangeTextureState;
    }

    private void OnDisable()
    {
        GameManager.TextureStateChanged -= ChangeTextureState;
    }
}
