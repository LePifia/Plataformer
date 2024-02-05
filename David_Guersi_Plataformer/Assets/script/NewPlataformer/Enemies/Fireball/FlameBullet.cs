using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBullet : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerStats playerStat;

    [SerializeField] Rigidbody2D enemyRB;

    [SerializeField] float forceFlame;
    private float timer;
    [SerializeField] float flameTimer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<PlayerStats>();
        enemyRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Vector3 direction = player.transform.position - transform.position;
        enemyRB.velocity = new Vector3(direction.x, direction.y, 0).normalized * forceFlame;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > flameTimer)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D playerKill)
    {

        if (playerKill.collider.tag == "Player")
        {
            playerStat.TakeDamage(1);
        }
    }
}
