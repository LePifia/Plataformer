using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    private  Rigidbody2D rigidbody2D;

    [Header("Knockback")]
    [SerializeField] float KnockbackForce = 50;

    private Vector3 direction;

    private void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigidbody2D != null)
        {
            direction =  collision.transform.position - transform.position;
            direction.y = .5f;
        }
    }

    public void KnockBackEffect()
    {

            rigidbody2D.AddForce(direction.normalized * KnockbackForce, ForceMode2D.Impulse);
              
    }
}
