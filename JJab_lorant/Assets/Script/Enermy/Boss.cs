using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Transform player;
    public float Range = 20f;
    public float hp = 10000f;
    public float attackRange = 10f;
    public float speed = 4;
    public int damage = 10;

    private NavMeshAgent agent;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public PlayerManager pm;
    public AudioPlayer ap;

    bool playerInRange = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        pm = FindObjectOfType<PlayerManager>();
        ap = FindObjectOfType<AudioPlayer>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if (dist <= Range)
        {
            if (!playerInRange)
            {
                playerInRange = true;
                ap.DetectSound();
            }

            agent.SetDestination(player.position);

            Vector3 lookPos = player.position;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);

            if (dist <= attackRange)
            {
                Shoot();
                ap.PlaySound();
            }
        }
        else
        {
            // Range 밖
            playerInRange = false;
            agent.ResetPath();
        }

        if (pm.currentHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hp -= pm.damage;

            if (hp <= 0)
                Destroy(gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
