using UnityEngine;

public class BedLogic : MonoBehaviour, IInteractable
{
    [SerializeField] GameState _state;

    public void InteractedWith(RaycastHit hitinfo)
    {
        if (GameManager.Instance.CurrentState == _state)
        {
            GameManager.Instance.ChangeState(GameState.FallSleep);
        }
    }
}
