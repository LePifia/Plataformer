using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRun : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rigidbody2d;
    private bool facingRight = true;
    [SerializeField] Collider2D standingCollider;

    [Range(0, .3f)]
    [SerializeField]
    private float movementSmoothing = .05f;

    private Vector3 velocity = Vector3.zero;
    [SerializeField] private LayerMask whatIsGround;

    //Movement
    [SerializeField] float speed;
    private float actualSpeed;
    [SerializeField] float reducedSpeed;
    [SerializeField] Vector3 direction;

    [Header("Events")]
    [Space]

    public UnityEvent OnMoveEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();

        if (OnMoveEvent == null)
            OnMoveEvent = new UnityEvent();

        actualSpeed = speed;

    }

    private void FixedUpdate()
    {
        //Movement
        CharacterMovement(direction.x);  
    }

    void CharacterMovement(float horizontal)
    {


        direction = new Vector3(Input.GetAxis("Horizontal") * actualSpeed, rigidbody2d.velocity.y, 0);

        OnMoveEvent.Invoke();

            if (rigidbody2d.velocity.x <= actualSpeed)
            {
                rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, direction, ref velocity, movementSmoothing);
            }

            if (horizontal > 0 && !facingRight)
            {
                Flip();
            }

            else if (horizontal < 0 && facingRight)
            {
                Flip();
            }
        
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
