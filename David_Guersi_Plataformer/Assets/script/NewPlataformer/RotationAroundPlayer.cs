using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundPlayer : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 5;
    [SerializeField] GameObject pivotingObject;

    void Update()
    {

        if (pivotingObject == null)
        {
            pivotingObject = GameObject.Find("Sun");
        }

        transform.RotateAround(pivotingObject.transform.position, new Vector3(0, 0, 1), rotationSpeed*Time.deltaTime);
    }
}
