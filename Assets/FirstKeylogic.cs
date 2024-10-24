using UnityEngine;

public class FirstKeylogic : MonoBehaviour, IInteractable
{
    [SerializeField] GameState _gameState;
    public void InteractedWith(RaycastHit hitinfo)
    {
        if (_gameState == GameManager.Instance.CurrentState)
        {
            //GameManager.Instance.ChangeState(GameState.FindKeyEarly);
        }
    }
}
