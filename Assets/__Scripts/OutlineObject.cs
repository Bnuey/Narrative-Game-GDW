using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    [SerializeField] GameObject _object;
    public void UpdateOutline(bool result)
    {
        if (result)
            _object.layer = 7;
        else
            _object.layer = 0;
    }


}
