using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    public Transform orientation;
    public Transform playerBody;

    public KeyCode slideKey = KeyCode.LeftShift;

    public float slideYScale = 0.5f;
    public float slideTime = 0.7f;
    public float slideForce = 20f;

    float startYScale;
    bool isSliding = false;
    float slideTimer;

    Rigidbody rb;
    float h;
    float v;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startYScale = playerBody.localScale.y;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKey) && (h != 0 || v != 0) && !isSliding)
        {
            StartSlide();
        }
    }

    void FixedUpdate()
    {
        if (isSliding)
        {
            SlideMove();
        }
    }

    void StartSlide()
    {
        isSliding = true;
        slideTimer = slideTime;

        playerBody.localScale = new Vector3(playerBody.localScale.x, slideYScale, playerBody.localScale.z);

        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
    }

    void SlideMove()
    {
        Vector3 dir = orientation.forward * v + orientation.right * h;
        dir.Normalize();

        rb.AddForce(dir * slideForce, ForceMode.Force);

        slideTimer -= Time.fixedDeltaTime;
        if (slideTimer <= 0f)
            StopSlide();
    }

    void StopSlide()
    {
        isSliding = false;

        playerBody.localScale = new Vector3(playerBody.localScale.x, startYScale, playerBody.localScale.z);
    }
}
