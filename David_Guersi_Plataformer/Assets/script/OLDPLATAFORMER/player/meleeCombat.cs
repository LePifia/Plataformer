using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class meleeCombat : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform attackPoint;
    [SerializeField] Transform attackPoint2;
    [SerializeField] float attackRange = 0.5f;

    [SerializeField] int attackDamage = 1;

    [SerializeField] playerMovement playerMove;

    [SerializeField] LayerMask enemyLayer;

    private bool rightReference;
    private bool leftReference;


    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        attackPoint = GameObject.Find("AttackPoint").transform;
        attackPoint2 = GameObject.Find("AttackPoint2").transform;
        playerMove = gameObject.GetComponent<playerMovement>();
        enemyLayer = LayerMask.GetMask("Enemy");
    }
    void Update()
    {
        rightReference = playerMove.right;
        leftReference = playerMove.left;
    }

    void OnFire()
    {
        Attack();
    }

    void Attack()
    {
        //Animation
        animator.SetTrigger("Attack");

        //EnemyDettect

        for (int counter = 0; counter <= 60; counter++)
        {
            if (rightReference == true)
            {
                Collider2D[] enemyhitted = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                //DamageEnemies
                foreach (Collider2D enemy in enemyhitted)
                {
                    enemy.GetComponent<Enemy>().DamageEnemy(attackDamage);
                }
            }

            if (leftReference == true)
            {
                Collider2D[] enemyhitted2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, enemyLayer);


                //DamageEnemies
                foreach (Collider2D enemy in enemyhitted2)
                {
                    enemy.GetComponent<Enemy>().DamageEnemy(attackDamage);
                }
            }
            //Physics.OverlapSphere for 3d games
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

        if (attackPoint2 == null) return;
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
    }
}
