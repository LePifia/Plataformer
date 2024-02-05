using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFallDead : MonoBehaviour
{
    [SerializeField] GameObject gravityDeadMarker;

    [Header("Events")]
    [Space]

    public UnityEvent OnFallEvent;
    private void FixedUpdate()
    {
        if(gameObject.transform.position.y <= gravityDeadMarker.transform.position.y)
        {
            OnFallEvent.Invoke();
        }
    }
}
