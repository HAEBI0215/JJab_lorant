using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 2000f;
    public float destroyTime = 1.5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed);

        Destroy(gameObject, destroyTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
