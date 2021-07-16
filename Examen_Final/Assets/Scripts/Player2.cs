using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
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
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.back * force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.forward * (force));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.right * force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.left * force);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force);
        }
    }
}
