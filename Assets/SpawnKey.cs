using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    [SerializeField] GameObject _keyFab;

    public void SpawnTheKey(GameState state)
    {
        if (state != GameState.GiveKey) return;

        var key = Instantiate(_keyFab);
        key.transform.position = transform.position;
    }

    private void OnEnable()
    {
        GameManager.OnAfterStateChange += SpawnTheKey;
    }
    private void OnDisable()
    {
        GameManager.OnAfterStateChange -= SpawnTheKey;
    }
}
