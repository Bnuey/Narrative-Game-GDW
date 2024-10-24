using UnityEngine;

public class SetGameState : MonoBehaviour, IInteractable
{
    public void InteractedWith(RaycastHit hitinfo)
    {
        GameManager.Instance.ChangeState(GameState.Option9);
    }
}
