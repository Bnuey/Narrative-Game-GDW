using UnityEngine;

public class PushPlayerIntoVoid : MonoBehaviour
{
    [SerializeField] Vector3 _moveToPos;
    async void PushPlayerIntoPit(GameState state)
    {
        if (state != GameState.Option13) return;

        transform.position = _moveToPos;
        await Awaitable.WaitForSecondsAsync(0.2f);
        GameManager.Instance.HideTextBox();
    }

    private void OnEnable()
    {
        GameManager.OnAfterStateChange += PushPlayerIntoPit;
    }

    private void OnDisable()
    {
        GameManager.OnAfterStateChange -= PushPlayerIntoPit;
    }
}
