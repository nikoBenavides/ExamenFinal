using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class RigidbodyPlayerController : MonoBehaviour
{

    public enum PlayerControls { WASD, Arrows }
    public PlayerControls playerControls = PlayerControls.WASD;
    public float movementSpeed = 3f;
    public float rotationSpeed = 5f;

    Rigidbody r;
    float gravity = 10.0f;

    void Awake()
    {
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        r.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move Front/Back
        Vector3 targetVelocity = Vector3.zero;
        if ((playerControls == PlayerControls.WASD && Input.GetKey(KeyCode.W)) || (playerControls == PlayerControls.Arrows && Input.GetKey(KeyCode.UpArrow)))
        {
            targetVelocity.z = 1;
        }
        else if ((playerControls == PlayerControls.WASD && Input.GetKey(KeyCode.S)) || (playerControls == PlayerControls.Arrows && Input.GetKey(KeyCode.DownArrow)))
        {
            targetVelocity.z = -1;
        }
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= movementSpeed;

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = r.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        float maxVelocityChange = 10.0f;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        r.AddForce(velocityChange, ForceMode.VelocityChange);

        // We apply gravity manually for more tuning control
        r.AddForce(new Vector3(0, -gravity * r.mass, 0));


        // Rotate Left/Right
        if ((playerControls == PlayerControls.WASD && Input.GetKey(KeyCode.A)) || (playerControls == PlayerControls.Arrows && Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Rotate(new Vector3(0, -14, 0) * Time.deltaTime * rotationSpeed, Space.Self);
        }
        else if ((playerControls == PlayerControls.WASD && Input.GetKey(KeyCode.D)) || (playerControls == PlayerControls.Arrows && Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Rotate(new Vector3(0, 14, 0) * Time.deltaTime * rotationSpeed, Space.Self);
        }
    }
}