using UnityEngine;

public class BedLogic : MonoBehaviour, IInteractable
{
    [SerializeField] GameState[] _state;

    public void InteractedWith(RaycastHit hitinfo)
    {
        switch (GameManager.Instance.CurrentState)
        {
            case GameState.GoToBed:
                GameManager.Instance.ChangeState(GameState.BadEnding2);
                break;

            case GameState.FindMedsEarly:
                GameManager.Instance.ChangeState(GameState.BadEnding1);
                break;

            case GameState.Option10:
                GameManager.Instance.ChangeState(GameState.BadEnding2);
                break;
        }
    }
}
