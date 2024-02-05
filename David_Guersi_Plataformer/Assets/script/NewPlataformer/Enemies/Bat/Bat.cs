using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] PlayerStats playerStat;

    [SerializeField] Transform target;

    [SerializeField] Rigidbody2D enemyRB;

    [SerializeField] float moveSpeed;

    public bool falling;

    private Vector3 moveDirection;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<PlayerStats>();
        target = player.transform;
        enemyRB = gameObject.GetComponent<Rigidbody2D>();  
    }

    void Start()
    {
        StartCoroutine(Falling());
    }

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
        

        if (falling == true)
        {
            enemyRB.velocity = new Vector3(moveDirection.x, moveDirection.y, 0) * moveSpeed;
        }

        if (falling == false)
        {
            enemyRB.velocity = new Vector3(-moveDirection.x, -moveDirection.y, 0) * moveSpeed/2;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D playerKill)
    {
        
        if (playerKill.collider.tag == "Player")
        {
            playerStat.TakeDamage(1);
        }
    }

    public IEnumerator Falling()
    {
        yield return new WaitForSeconds(5.0f);

        falling ^= true;

        StartCoroutine(Falling());
    }

}
    
