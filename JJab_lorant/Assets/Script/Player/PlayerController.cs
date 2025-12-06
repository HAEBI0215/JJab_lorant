using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : PlayerManager
{
    public Rigidbody rb;
    public float speed = 10f;

    public Vector3 moveDirection;
    public float mouseSensitivity = 2f;
    public Transform cam;
    public float moveX;
    public float moveZ;

    float mouseX;
    float mouseY;
    float camRotX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHp = 100;
        currentHp = maxHp;
        damage = 50;
        cirtDamage = damage * 2;
        isDead = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
    }

    void PlayerMove()
    {
        Vector3 camForward = cam.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = cam.right;
        camRight.y = 0f;
        camRight.Normalize();

        moveDirection = camForward * moveZ + camRight * moveX;
        moveDirection = moveDirection.normalized * speed;

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }

    void CameraMove()
    {
        transform.Rotate(Vector3.up * mouseX);

        camRotX -= mouseY;
        camRotX = Mathf.Clamp(camRotX, -90f, 90f);

        cam.localRotation = Quaternion.Euler(camRotX, 0f, 0f);
    }

    private void FixedUpdate()
    {
        PlayerMove();
        CameraMove();
    }
}
