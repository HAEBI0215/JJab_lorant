using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    PlayerManager pm;
    public GameObject bulletPrefab;
    public GameObject firePos; //생성 위치
    public Transform firePoint; //발사 위치
    public GameObject Scope;

    public bool hasGoodThings = false;
    public float scopeFov = 40f;
    public float hasGoodScopeFov = 20f;
    public float normalFov = 60f;

    public bool hasStock = false;
    public float baseBandong = 10f;
    public float reduceBandong = 1.2f;

    Camera cam;
    float currentBandong = 0;

    private void Awake()
    {
        cam = Camera.main;
        Scope.gameObject.SetActive(false);
    }

    private void Update()
    {
        bool isAiming = Input.GetMouseButton(1);
        float targetFov = normalFov;

        if (isAiming && Scope != null)
        {
            targetFov = scopeFov;

            Scope.gameObject.SetActive(true);
            hasGoodThings = true;
            if (isAiming && hasGoodThings == true)
                targetFov = hasGoodScopeFov;
        }

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFov, Time.deltaTime * 4f);
        

        if (currentBandong > 0f)
        {
            float recover = 10f;
            currentBandong = Mathf.Max(0f, currentBandong - recover);
            cam.transform.localRotation = Quaternion.Euler( - currentBandong, 0f, 0f);
        }
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.forward = Camera.main.transform.forward;

        ApplyBandong();
    }

    private void ApplyBandong()
    {
        float bandong = baseBandong;
        if (hasStock)
            bandong *= reduceBandong;

        currentBandong *= bandong;
        cam.transform.localRotation = Quaternion.Euler( - currentBandong, 0f, 0f);
    }
}
