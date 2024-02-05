using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateMAchine : MonoBehaviour
{
    [SerializeField] MonoBehaviour slime;

    [SerializeField]float timer = 2.5f;
 

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && slime.isActiveAndEnabled == true)
        {
            slime.enabled = false;

            timer = 3f;

        }

        if (timer <= 0 && slime.isActiveAndEnabled == false)
        {
            slime.enabled = true;

            timer = 3f;
        }
 
    }
}
