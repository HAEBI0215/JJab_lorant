using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Transform player;
    public float Range = 10000f;
    public float hp = 10000f;
    public float attackRange = 100000f;
    public float speed = 4;
    public int damage = 10;

    private NavMeshAgent agent;
    public GameObject bulletPrefab;
    public GameObject firePos; //생성 위치
    public Transform firePoint; //발사 위치
    public PlayerManager pm;
    public AudioPlayer ap;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        pm = FindObjectOfType<PlayerManager>();
        ap = FindObjectOfType<AudioPlayer>();
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
            }
            else
            {
                agent.ResetPath();
            }
            ap.DetectSound();
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

            if (hp == 0)
                Destroy(gameObject);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
