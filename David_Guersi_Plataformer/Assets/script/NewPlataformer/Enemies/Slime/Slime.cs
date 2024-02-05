using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{

    [SerializeField] Animator animator;

    [SerializeField] GameObject player;
    [SerializeField] PlayerStats playerStat;

    [SerializeField] Transform target;

    [SerializeField] float lookRadius;

    [SerializeField] Rigidbody2D enemyRB;

    //JUMP
    [SerializeField] float jumpTime;
    [SerializeField] float jumpTimerCount;
    private bool isGrounded;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerStat = player.GetComponent<PlayerStats>();
        target = player.transform;
        enemyRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        EnemyMovement(1);

        if ( distance < lookRadius)
        {
                Jump();
                isGrounded = false;
                jumpTimerCount -= Time.deltaTime;
            
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {   
        
        isGrounded = true;
            if (isGrounded == true)
            {
                jumpTimerCount = jumpTime;
            }
    }

    private void OnCollisionEnter2D(Collision2D playerKill)
    {
        animator.SetBool("Jumping", false);
        if (playerKill.collider.tag == "Player")
        {
            playerStat.TakeDamage(1);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Jump()
    {
        if (jumpTimerCount > 0)
        {
            enemyRB.velocity = new Vector2(enemyRB.velocity.x, 0);
            enemyRB.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
        }
    }

    void EnemyMovement(float horizontal)
    {

        if (player.transform.position.x <= transform.position.x)
        {
            if (enemyRB.velocity.x <= 2)
            {
                enemyRB.AddForce(-Vector2.right * horizontal * .5f);
            }
        }

        if (player.transform.position.x >= transform.position.x)
        {
            if (enemyRB.velocity.x <= 2)
            {
                enemyRB.AddForce(Vector2.right * horizontal * .5f);
            }
        }


    }

    

}
