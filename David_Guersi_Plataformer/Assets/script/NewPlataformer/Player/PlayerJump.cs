using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rigidbody2d;

    private PlayerCrouch playerCrouch;

    [Range(0, .3f)]
    [SerializeField]
    private float movementSmoothing = .05f;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] bool doubleJump;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] float maxJumpSpeed = 4;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

    [SerializeField] Vector3 direction;

    [SerializeField] Collider2D playerCollider;

    const float groundedRadius = .05f;
    private bool grounded;

     [SerializeField]float timer;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;


    [Space]

    public UnityEvent OnJumpEvent;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        playerCrouch = gameObject.GetComponent<PlayerCrouch>();
    }
    private void Update()
    {
        if (grounded == false)
        {
            timer += Time.deltaTime;
        }
        
    }
    private void FixedUpdate()
    {
        if (rigidbody2d.velocity.y >= maxJumpSpeed)
        {
            rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, direction, ref velocity, movementSmoothing);
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                doubleJump = true;

                if(playerCollider.IsTouchingLayers(LayerMask.GetMask("ground")))
                {
                    OnLandEvent.Invoke();
                    timer = 0;
                }
                
            }
        }
    }

    public void OnJumper()
    {
      if (playerCrouch.Crouched == false)
        {
            if (grounded == true)
            {
                OnJumpEvent.Invoke();
                grounded = false;
                rigidbody2d.AddForce(new Vector2(0f, jumpForce));
            }

            if (doubleJump == true)
            {
                doubleJump = false;
                rigidbody2d.AddForce(new Vector2(0f, jumpForce));
            }
        }  
        
    }
}
