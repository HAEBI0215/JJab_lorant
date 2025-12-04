using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : PlayerManager
{
    public Rigidbody rb;
    public float speed = 10f;
    public bool isShoot = false;
    public Vector3 moveDirection;
    MoveManager movemanager;

    void Start()
    {
        maxHp = 100;
        currentHp = maxHp;
        damage = 50;
        cirtDamage = damage * 2;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isShoot = true;
        }
        float horizontalInput = MoveManager.Instance.horizontalInput;
        float verticalInput = MoveManager.Instance.VerticalInput;

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection.Normalize();
    }

    void PlayerMove()
    {
         rb.AddForce(moveDirection * speed, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

}
