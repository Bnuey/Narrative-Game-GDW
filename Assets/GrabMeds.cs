using UnityEngine;

public class GrabMeds : MonoBehaviour, IInteractable
{
    public void InteractedWith(RaycastHit hitinfo)
    {
        switch (GameManager.Instance.CurrentState)
        {
            case (GameState.TalkToMaid):
                GameManager.Instance.ChangeState(GameState.FindMedsEarly);
                break;
            case (GameState.FindMeds):
                GameManager.Instance.ChangeState(GameState.FoundMeds);
                break;

            case GameState.Option1:
                GameManager.Instance.ChangeState(GameState.FindMedsEarly);
                break;

            case GameState.Option2:
                GameManager.Instance.ChangeState(GameState.FindMedsEarly);
                break;

            case GameState.Option3:
                GameManager.Instance.ChangeState(GameState.FindMedsEarly);
                break;
        }
    }
}
