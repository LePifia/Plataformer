using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsRepresentation : MonoBehaviour
{
    private int health;

    private int numOfHearts = 5;

    public Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    [SerializeField] GameObject player;

   
    private void Start()
    {
        health = player.GetComponent<PlayerStats>().GetHealth();
        numOfHearts = health;
    }
    void Update()
    {
        health = player.GetComponent<PlayerStats>().GetHealth();

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;   
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
