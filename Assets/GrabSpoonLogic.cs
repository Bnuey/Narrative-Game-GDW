using UnityEngine;

public class GrabSpoonLogic : MonoBehaviour, IInteractable
{
    public void InteractedWith(RaycastHit hitinfo)
    {
        GameManager.Instance.ChangeState(GameState.FoundSpoon);
    }
}
