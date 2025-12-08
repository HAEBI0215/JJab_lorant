using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 1000f;
    public float destroyTime = 1.5f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed);

        Destroy(gameObject, destroyTime);
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Bullet Trigger Hit: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Eenemy"))
        {
            Destroy(gameObject);
        }
    }
}
