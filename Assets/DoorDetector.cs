using SmartData.SmartBool;
using UnityEngine;
using UnityEngine.Events;

public class DoorDetector : MonoBehaviour
{
    [SerializeField] UnityEvent _event;

    [SerializeField] BoolReader _npcTalking;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "FakeDoor":
                if (!_npcTalking.value)
                    _event.Invoke();
                break;
            case "Prince":
                GameManager.Instance.ChangeState(GameState.GoodEnding2);
                break;
            case "Player":
                GameManager.Instance.ChangeState(GameState.GoodEnding1);
                break;
        }

    }
}
