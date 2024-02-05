using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateMachine : MonoBehaviour
{
    [SerializeField] MonoBehaviour [] playerScripts;

    bool finishLine = false;


    void Update()
    {
        if (finishLine == true)
        {
            foreach(MonoBehaviour playerScript in playerScripts)
            {
                playerScript.enabled = false;
            }
        }
    }

    public void finishLevel()
    {
        finishLine = true;
    }
}
