using UnityEngine;

public class BedLogic : MonoBehaviour, IInteractable
{
    [SerializeField] GameState[] _state;

    public void InteractedWith(RaycastHit hitinfo)
    {
        foreach (var state in _state)
        {
            if (GameManager.Instance.CurrentState == state)
            {
                GameManager.Instance.ChangeState(GameState.FallSleep);
            }
        }
    }
}
