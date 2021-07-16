using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    private Rigidbody rb;
    private int force = 20;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * force);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * (force));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * force);
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            rb.AddForce(Vector3.up * force);
        }
    }
}
