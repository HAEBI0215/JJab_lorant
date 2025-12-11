using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Transform player;
    public float Range = 80f;
    public float hp = 500f;
    public float attackRange = 70f;
    public float speed = 4;
    private float lastAttackTime = -999f;

    private NavMeshAgent agent;
    public GameObject bulletPrefab;
    public GameObject firePos; //생성 위치
    public Transform firePoint; //발사 위치
    public PlayerManager pm;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        pm = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < Range)
        {
            agent.SetDestination(player.position);

            Vector3 lookPos = player.position;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
            if(dist > attackRange)
            {
                Shoot();
                lastAttackTime = Time.time;
            }
            else
            {
                agent.ResetPath();
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp -= pm.damage;
            Debug.Log("Boss Hit! Current HP: " + hp);

            if (hp == 0)
                Destroy(gameObject);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
