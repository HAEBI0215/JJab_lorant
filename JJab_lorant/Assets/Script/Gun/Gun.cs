using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    PlayerManager pm;
    public GameObject bulletPrefab;
    public GameObject firePos; //생성 위치
    public Transform firePoint; //발사 위치
    void Start()
    {
        
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.forward = Camera.main.transform.forward;
    }
}
