using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStateMachine : MonoBehaviour
{
    [SerializeField] MonoBehaviour rotation;
    [SerializeField] MonoBehaviour bat;
    [SerializeField] float timer = 2.5f;


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && rotation.enabled == true)
        {
            rotation.enabled = false;
            bat.enabled = true;
            timer = 3f;

        }

        if (timer <= 0 && rotation.enabled == false)
        {
            rotation.enabled = true;
            bat.enabled = false;

            timer = 3f;
        }
    }
}
