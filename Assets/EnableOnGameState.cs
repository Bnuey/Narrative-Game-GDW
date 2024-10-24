using UnityEngine;

public class EnableOnGameState : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] Grabable _grab;

    void CheckToEnable(GameState state)
    {
        if (state != gameState) return;

        _grab.enabled = true;
    }

    private void OnEnable()
    {
        GameManager.OnAfterStateChange += CheckToEnable;
    }

    private void OnDisable()
    {
        GameManager.OnAfterStateChange -= CheckToEnable;
    }
}
