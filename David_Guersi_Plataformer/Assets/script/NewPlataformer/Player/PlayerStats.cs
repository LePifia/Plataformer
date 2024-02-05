using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] int health = 5;

    [Header("Events")]
    [Space]

    public UnityEvent OnHitEvent;

    [Space]
    public UnityEvent OnDieEvent;

    private void Update()
    {
        if (health <= 0)
        {
            DIE();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }
    public void TakeDamage (int Damage)
    {
        OnHitEvent.Invoke();
        health -= Damage;

        if (health <= 0)
        {
            DIE();
        }
    }

    public void DIE()
    {
        OnDieEvent.Invoke();
        gameObject.SetActive(false);
    }

    public int GetHealth()
    {
        return health;
    }

    
}
