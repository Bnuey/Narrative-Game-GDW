using UnityEngine;

public class ChangeObjectiveText : MonoBehaviour, IInteractable
{
    [SerializeField] string _objectiveText;

    public void InteractedWith(RaycastHit hitinfo)
    {
        GameManager.Instance.SetObjectiveText(_objectiveText);
    }
}
