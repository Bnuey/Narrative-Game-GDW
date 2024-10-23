using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BOING : MonoBehaviour
{
    [SerializeField] float _bounceForce;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().velocity += new Vector3(0, _bounceForce, 0);
        }
    }
}
