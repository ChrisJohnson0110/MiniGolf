using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallPhysicsController : MonoBehaviour
{
    public float friction = 0.98f; // 0.98 means lose 2% speed per frame
    public float stopThreshold = 0.05f;
    public float collisionDampFactor = 0.6f; // lose 40% speed on impact

    private Rigidbody rb;
    private Vector3 lastVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0;
        rb.angularDrag = 0;
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > stopThreshold)
        {
            rb.velocity *= friction;

            // Optional: slow angular velocity too
            rb.angularVelocity *= friction;
        }
        else
        {
            // Snap to full stop
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Damp the speed upon hitting anything
        if (rb.velocity.magnitude > 0.1f)
        {
            rb.velocity *= collisionDampFactor;
        }
    }
}