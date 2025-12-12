using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public int maxHp = 100;
    [SerializeField] public int currentHp;
    [SerializeField] public int damage = 50;
    [SerializeField] public int critDamage;
    [SerializeField] public bool isDead = false;
    [SerializeField] public bool isShoot = false;
    [SerializeField] public int ammo = 15;

    [SerializeField] Bullet bullet;
    [SerializeField] Gun gun;
    [SerializeField] AudioPlayer audio;
    [SerializeField] public TMP_Text ammoTxT;
    [SerializeField] public TMP_Text hpTxT;
    [SerializeField] public RawImage deadVedio;
    [SerializeField] Boss boss;
    [SerializeField] public ButtonManager buttonManager;

    void Start()
    {
        currentHp = maxHp;
        critDamage = damage * 2;
        isDead = false;
        isShoot = false;
        deadVedio.gameObject.SetActive(false);
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && ammo != 0)
        {
            isShoot = true;
            gun.Fire();
            audio.PlaySound();

            ammo--;

            ammoTxT.text = ($"{ammo} / 15");
        }
        else
        {
            isShoot = false;
        }
    }

    void Reload()
    {
        if(ammo >= 0 && ammo != 15)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ammo = 15;
                ammoTxT.text = ($"{ammo} / 15");

                audio.ReloadSound();
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHp -= boss.damage;
            hpTxT.text = ($"{currentHp} / 100");
            audio.HitSound();
        }
    }

    void Update()
    {
        Shoot();
        Reload();

        if (currentHp <= 0)
        {
            deadVedio.gameObject.SetActive(true);

            gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            buttonManager.ShowButton();
        }
    }
}
