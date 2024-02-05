using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{

    private GameObject player;
    [SerializeField] PlayerStats playerStat;

    [SerializeField] Transform target;

    [SerializeField] Rigidbody2D enemyRB;

    [SerializeField] float lookRadius;

    //shoot
    [SerializeField] GameObject flame;
    [SerializeField] Transform flamePos;

    [SerializeField] float timer;
    [SerializeField] float flameTimer;
    [SerializeField] float distance;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<PlayerStats>();
        target = player.transform;
        enemyRB = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D playerKill)
    {
        if (playerKill.collider.tag == "Player")
        {
            playerStat.TakeDamage(1);
        }
    }
    void Update()
    {
        distance = Vector2.Distance(target.position, transform.position);

        if (distance < lookRadius)
        {
            timer += Time.deltaTime;
        }

        if (timer > flameTimer)
        {
            timer = 0;
            Shoot();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Shoot()
    {
        Instantiate(flame, flamePos.position, Quaternion.identity);
    }
}
