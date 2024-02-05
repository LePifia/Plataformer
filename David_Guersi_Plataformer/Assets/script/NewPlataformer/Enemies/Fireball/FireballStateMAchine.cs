using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballStateMAchine : MonoBehaviour
{
    [SerializeField] MonoBehaviour rotation;
    [SerializeField] MonoBehaviour fireball;
    [SerializeField] float timer = 2.5f;



    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && rotation.enabled == true)
        {
            rotation.enabled = false;
            fireball.enabled = true;
            timer = 3f;

        }

        if (timer <= 0 && rotation.enabled == false)
        {
            rotation.enabled = true;
            fireball.enabled = false;

            timer = 3f;
        }
    }
}
