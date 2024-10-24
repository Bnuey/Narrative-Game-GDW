using UnityEngine;

public class DestroyOnCertainGameState : MonoBehaviour
{
    [SerializeField] GameState _gameState;

    void CheckToDestroy(GameState state)
    {
        if (state != _gameState) return;

        Destroy(gameObject);
    }

    private void OnEnable()
    {
        GameManager.OnAfterStateChange += CheckToDestroy;
    }

    private void OnDisable()
    {
        GameManager.OnAfterStateChange -= CheckToDestroy;
    }
}
