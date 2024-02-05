using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour


{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        transform.position = player.transform.position + new Vector3 (0,0.85f,-10 );
    }
}
