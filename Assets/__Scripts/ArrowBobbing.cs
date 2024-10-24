using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowBobbing : MonoBehaviour
{

    [SerializeField] private Transform player;


    private float xPos;
    private float yPos;
    private float zPos;

    private Transform trans;


    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        xPos = GetComponent<Transform>().position.x;
        yPos = GetComponent<Transform>().position.y;
        zPos = GetComponent<Transform>().position.z;
    }

    // Update is called once per frame
    void Update()
    {
        trans.position = new Vector3(xPos, yPos + 0.2f * Mathf.Sin(Time.realtimeSinceStartup * 2), zPos);

        trans.LookAt(player);
    }
}
