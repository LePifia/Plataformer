using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parallaxMovement : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float lagAmount;
    private GameObject player;

    private Camera cam;
    private Vector3 previousCaMPos;
    private float parallaxEffect => 1f - lagAmount;

    [SerializeField] bool infinityPlanex;

    private Vector3 targetPosition;
  
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        previousCaMPos = cam.transform.position;
    }

    private void Update()
    {
        if (player.transform.position.x > gameObject.transform.position.x + gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2)
        {
            previousCaMPos = cam.transform.position;
            Vector3 newPos = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = newPos;
        }

        if (player.transform.position.x < gameObject.transform.position.x - gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2)
        {
            previousCaMPos = cam.transform.position;
            Vector3 newPos = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = newPos;
        }
    }

    private void LateUpdate()
    {
       
        if (infinityPlanex == true)
        {
            Vector3 movement = CameraMovement;
            if (movement == Vector3.zero) return;
            targetPosition = new Vector3(transform.position.x + movement.x * parallaxEffect, transform.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }

    Vector3 CameraMovement
    {
        get
        {
            Vector3 movement = cam.transform.position - previousCaMPos;
            previousCaMPos = cam.transform.position;
            return movement;
        }
    }

}
