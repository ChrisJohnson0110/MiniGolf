using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAligner : MonoBehaviour
{
    public Transform ballTransform;
    public float rotateSpeed = 50f;

    void Update()
    {
        // Keep aligner at ball's position
        Vector3 pos = ballTransform.position;
        //pos.y = transform.position.y; 
        pos.y = ballTransform.position.y + 0.5f;
        transform.position = pos;

        // Handle input
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal * rotateSpeed * Time.deltaTime, 0);
    }

    public Vector3 GetShotDirection()
    {
        return transform.forward.normalized;
    }
}