using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCrouch : MonoBehaviour
{
    bool crouch = false;

    [SerializeField] Collider2D standingCollider;
    [SerializeField] Transform overHeadCollider;
    const float overHeadCheckRadius = 0.1f;

    [SerializeField] private LayerMask whatIsRoof;

    public bool Crouched;

    [Header("Events")]
    [Space]

    public UnityEvent OnCrouchEvent;
    public UnityEvent OnStandUpEvent;

    public void OnCrouch()
    {

        Crouched = true;
        Debug.Log("crouch");
        crouch = !crouch;

        if (crouch == true)
        {
            OnCrouchEvent.Invoke();
            standingCollider.enabled = false;
        }
        else
        {
            if (Physics2D.OverlapCircle(overHeadCollider.position, overHeadCheckRadius, whatIsRoof) == null)

                StandUp();
            
        }
    }
    public void StandUp()
    {
        
        if (Physics2D.OverlapCircle(overHeadCollider.position,overHeadCheckRadius, whatIsRoof) == null)
            Crouched = false;
            crouch = false;
            standingCollider.enabled = true;
            OnStandUpEvent.Invoke();
    }
}
