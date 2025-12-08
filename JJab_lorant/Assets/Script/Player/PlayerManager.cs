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
    [SerializeField] public int ammo = 30;

    [SerializeField] Bullet bullet;
    [SerializeField] Gun gun;
    [SerializeField] AudioPlayer audio;

    void Start()
    {
        currentHp = maxHp;
        cirtDamage = damage * 2;
        isDead = false;
        isShoot = false;
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && ammo != 0)
        {
            isShoot = true;
            gun.Fire();
            audio.PlaySound();

            ammo--;

            //Debug.Log("Shoot");
            //Debug.Log($"remaining bullet : {ammo}");
        }
        else if (ammo == 0)
        {
            //Debug.Log("i need more bullet");
        }

        else
        {
            isShoot = false;
        }
    }

    void Reload()
    {
        if(ammo >= 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ammo = 30;
                //Debug.Log($"more bullet now : {ammo}");
                audio.ReloadSound();
            }
        }
    }

    void Update()
    {
        Shoot();
        Reload();
    }
}
