using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class LadderClimb : MonoBehaviour
{
    [SerializeField] Collider2D playerCollider;
    [SerializeField] Vector2 climbVelocity;
    private Rigidbody2D rigidbody2d;
    [SerializeField] float climbSpeed;

    float gravityScale;

    Vector3 direction;

    Vector2 climbInput;

    [Header("Events")]
    [Space]

    public UnityEvent OnClimbEvent;
    [Space]
    public UnityEvent OnStopClimbing;

    private void Awake()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        gravityScale = rigidbody2d.gravityScale;
    }

    private void Update()
    {
        //if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"))) { Debug.Log("Climbing"); }

    }

    private void FixedUpdate()
    {
        Climbing();
    }

    void Climbing()
    {
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"))) 
        {
            OnStopClimbing.Invoke();

            rigidbody2d.gravityScale = gravityScale;
            
            return;
        }

        OnClimbEvent.Invoke();
        rigidbody2d.gravityScale = 0;
        climbVelocity = new Vector2(rigidbody2d.velocity.x, climbInput.y * climbSpeed);
        rigidbody2d.velocity = climbVelocity;
        
    }

    void OnClimb(InputValue vertical)
    {
        
        climbInput = vertical.Get<Vector2>();
    }
}
