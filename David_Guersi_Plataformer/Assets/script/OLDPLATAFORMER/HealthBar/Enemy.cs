using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Health
    [SerializeField] int maxHealth = 1;
    [SerializeField] int currentHealth;

    [SerializeField] GameObject EnemyChosen;

    [SerializeField] Slime slime;
    [SerializeField] Bat bat;

    // Start is called before the first frame update

    private void Awake()
    {
        EnemyChosen = gameObject;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
   

    public void DamageEnemy(int damage)
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
        Debug.Log("ENEMY DEFFEATED");

        //DIEANIMATION
        EnemyChosen.GetComponent<Animator>().SetTrigger("Dead");

        if (EnemyChosen.GetComponent<Slime>())
        {
            EnemyChosen.GetComponent<Slime>().enabled = false;
        }

        if (EnemyChosen.GetComponent<Bat>())
        {
            EnemyChosen.GetComponent<Bat>().enabled = false;
        }

        StartCoroutine(DIE());

        
    }

    public IEnumerator DIE()
    {
        yield return new WaitForSeconds(1.0f);

        //DISABLE
        gameObject.SetActive(false);
    }
}
