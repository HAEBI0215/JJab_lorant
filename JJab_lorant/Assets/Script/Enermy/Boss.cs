using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Transform player;
    public float Range = 10f;
    public float attackRange = 15f;
    public float attackDelay = 0.4f;
    public float speed = 4;

    private NavMeshAgent agent;
    public GameObject bulletPrefab;
    public GameObject firePos; //생성 위치
    public Transform firePoint; //발사 위치

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < Range)
        {
            agent.SetDestination(player.position);
            transform.LookAt(player);
            if(dist > attackRange)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
