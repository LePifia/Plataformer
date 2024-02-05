using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour
{

    [SerializeField] Transform finishPoint;
    [SerializeField] float finishRange;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] MonoBehaviour finishLine;

    playerStats playerStats;

    [Header("Events")]
    [Space]

    public UnityEvent OnFinishEvent;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(finishPoint.position, finishRange);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] playerCollider = Physics2D.OverlapCircleAll(finishPoint.position, finishRange, playerLayer);


        foreach (Collider2D colision in playerCollider)
        {
            OnFinishEvent.Invoke();
            finishLine.enabled = false;
        }
    }
}
