using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{

    //Health
    [SerializeField] int maxHealth = 1;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        //¿Hurt Animation?
        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //DIEANIMATION
        gameObject.GetComponent<Animator>().SetTrigger("Dead");

        //DISABLE
        gameObject.SetActive(false);
    }
}
