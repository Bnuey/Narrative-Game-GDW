using UnityEngine;

public class TurnOutlineOff : MonoBehaviour
{
    void ChangeLayer(bool currentState)
    {
        if (!currentState)
        {
            gameObject.layer = 0;
        }
        else
        {
            gameObject.layer = 7;
        }
    }

    private void OnEnable()
    {
        GameManager.TextureStateChanged += ChangeLayer;
    }

    private void OnDisable()
    {
        GameManager.TextureStateChanged -= ChangeLayer;
    }
}
