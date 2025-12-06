using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public int maxHp = 100;
    [SerializeField] public int currentHp;
    [SerializeField] public int damage = 50;
    [SerializeField] public int cirtDamage;
    [SerializeField] public bool isDead = false;
    [SerializeField] public bool isShoot = false;

    [SerializeField] Bullet bullet;
    [SerializeField] Gun gun;

    void Start()
    {
        currentHp = maxHp;
        cirtDamage = damage * 2;
        isDead = false;
        isShoot = false;
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isShoot = true;
            gun.Fire();

            Debug.Log("Shoot");
        }
        else
        {
            isShoot = false;
        }
    }

    void Update()
    {
        Shoot();
    }
}
