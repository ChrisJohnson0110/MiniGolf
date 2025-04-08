using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetBall;
    public float rotateSpeed = 3f;
    public float moveSpeed = 5f;
    public KeyCode toggleFreeFlyKey = KeyCode.C;

    private bool isFreeFly = false;
    private Vector3 offset;

    public static bool IsInFreeCam { get; private set; }

    void Start()
    {
        offset = transform.position - targetBall.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleFreeFlyKey))
        {
            isFreeFly = !isFreeFly;
            IsInFreeCam = isFreeFly;
        }

        if (isFreeFly)
        {
            FreeFlyCamera();
        }
        else
        {
            OrbitCamera();
        }
    }

    void OrbitCamera()
    {
        float h = Input.GetAxis("Mouse X") * rotateSpeed;
        float v = Input.GetAxis("Mouse Y") * rotateSpeed;

        Quaternion rot = Quaternion.Euler(-v, h, 0);
        offset = rot * offset;

        transform.position = targetBall.position + offset;
        transform.LookAt(targetBall);
    }

    void FreeFlyCamera()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += transform.right * h * moveSpeed * Time.deltaTime;
        transform.position += transform.forward * v * moveSpeed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x - mouseY, transform.eulerAngles.y + mouseX, 0f);
    }
}