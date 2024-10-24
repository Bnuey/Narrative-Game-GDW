using UnityEngine;

public class DinnerAnim : MonoBehaviour
{
    public void AfterDinner()
    {
        GameManager.Instance.ChangeState(GameState.AfterDinner);
    }
}
