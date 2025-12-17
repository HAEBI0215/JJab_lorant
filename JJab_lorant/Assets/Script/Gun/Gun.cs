using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject Scope;

    bool hasScope = false;
    public float scopeFov = 65f;
    public float hasGoodScopeFov = 30f;
    public float normalFov = 60f;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    public void SetScope(bool isOn)
    {
        hasScope = isOn;
        if (!hasScope && Scope != null)
            Scope.SetActive(true);
    }

    void Update()
    {
        bool isAiming = Input.GetMouseButton(1);
        float targetFov = normalFov;

        if (isAiming && Scope != null && hasScope)
        {
            Scope.SetActive(true);
            targetFov = hasGoodScopeFov;
        }
        else if (isAiming && hasScope == false)
        {
            Scope.SetActive(false);
            targetFov = scopeFov;
        }

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFov, Time.deltaTime * 4f);
    }

    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.forward = Camera.main.transform.forward;
    }
}
