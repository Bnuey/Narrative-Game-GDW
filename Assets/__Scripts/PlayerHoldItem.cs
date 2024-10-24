using SmartData.SmartBool;
using UnityEngine;

public class PlayerHoldItem : MonoBehaviour
{
    public Grabable ItemBeingHeld;
    [SerializeField] GameObject _holdItemPos;

    [SerializeField] BoolWriter _holdingKey, _holdingSpoon;

    private Vector3 velocity = Vector3.zero;
    [SerializeField] float _smoothDampSpeed;

    [SerializeField] AudioClip _grabItemClip, _grabKeySound;

    public void GrabItem(Grabable grabable)
    {
        ItemBeingHeld = grabable;

        SoundFXManager.Instance.PlaySoundFXClip(_grabItemClip, transform, 0.4f, 1);

        if (grabable.CompareTag("Key"))
        {
            _holdingKey.value = true;

            //SoundFXManager.Instance.PlaySoundFXClip(_grabKeySound, transform, 0.5f, 1);
        }
        else if (grabable.CompareTag("Spoon"))
        {
            _holdingSpoon.value = true;
        }

        ItemBeingHeld.GetComponent<Collider>().enabled = false;
        ItemBeingHeld.GetComponent<Rigidbody>().useGravity = false;
    }

    public void ReleaseItem()
    {
        if (ItemBeingHeld == null) return;
        
        ItemBeingHeld.GetComponent<Collider>().enabled = true;
        ItemBeingHeld.GetComponent<Rigidbody>().useGravity = true;
        _holdingKey.value = false;
        ItemBeingHeld = null;
    }

    void DestroyKey()
    {
        if (_holdingKey.value)
        {
            ItemBeingHeld.GetComponent<Key>().KillKey();
            ReleaseItem();
        }
    }


    public void Update()
    {
        if (ItemBeingHeld == null) return;

        ItemBeingHeld.transform.rotation = Quaternion.Slerp(ItemBeingHeld.transform.rotation, _holdItemPos.transform.rotation, Time.deltaTime * _smoothDampSpeed * 100);
        ItemBeingHeld.transform.position = Vector3.SmoothDamp(ItemBeingHeld.transform.position, _holdItemPos.transform.position, ref velocity, _smoothDampSpeed);
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
