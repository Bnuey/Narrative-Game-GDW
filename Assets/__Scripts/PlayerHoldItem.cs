using SmartData.SmartBool;
using UnityEngine;

public class PlayerHoldItem : MonoBehaviour
{
    [SerializeField] Grabable _itemBeingHeld;
    [SerializeField] GameObject _holdItemPos;

    [SerializeField] BoolWriter _holdingKey;

    private Vector3 velocity = Vector3.zero;
    [SerializeField] float _smoothDampSpeed;

    public void GrabItem(Grabable grabable)
    {
        _itemBeingHeld = grabable;
        if (grabable.CompareTag("Key"))
            _holdingKey.value = true;

        _itemBeingHeld.GetComponent<Collider>().enabled = false;
        _itemBeingHeld.GetComponent<Rigidbody>().useGravity = false;
    }

    public void ReleaseItem()
    {
        if (_itemBeingHeld == null) return;
        
        _itemBeingHeld.GetComponent<Collider>().enabled = true;
        _itemBeingHeld.GetComponent<Rigidbody>().useGravity = true;
        _holdingKey.value = false;
        _itemBeingHeld = null;
    }

    void DestroyKey()
    {
        if (_holdingKey.value)
        {
            _itemBeingHeld.GetComponent<Key>().KillKey();
            ReleaseItem();
        }
    }


    public void Update()
    {
        if (_itemBeingHeld == null) return;

        _itemBeingHeld.transform.rotation = Quaternion.Slerp(_itemBeingHeld.transform.rotation, _holdItemPos.transform.rotation, Time.deltaTime * _smoothDampSpeed * 100);
        _itemBeingHeld.transform.position = Vector3.SmoothDamp(_itemBeingHeld.transform.position, _holdItemPos.transform.position, ref velocity, _smoothDampSpeed);
    }

    private void OnEnable()
    {
        Grabable.ItemGrabbed += GrabItem;
        PlayerInteraction.ReleaseObject += ReleaseItem;
        Key.DestroyKey += DestroyKey;
    }

    private void OnDisable()
    {
        Grabable.ItemGrabbed -= GrabItem;
        PlayerInteraction.ReleaseObject -= ReleaseItem;
        Key.DestroyKey -= DestroyKey;
    }
}
