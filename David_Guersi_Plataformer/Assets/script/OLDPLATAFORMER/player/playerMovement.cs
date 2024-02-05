using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    //Player
    [SerializeField] GameObject Player;
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] playerStats playerStat;
    public bool right;
    public bool left;

    //MenuAcces
    [SerializeField] MainMenu mainMenu;

    //Movement
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    public Vector2 moveInput;

    //Animation
    [SerializeField] Animator animator;


    //JUMP
    public Vector3 Jumper;
    [SerializeField] float jumpSpeed;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpTimerCount;
    

    public bool Jumping;
    public bool DoubleJump;
    public bool isGrounded;

    private void Awake()
    {
        Player = gameObject;
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        mainMenu = GameObject.FindGameObjectWithTag("end").GetComponent<MainMenu>();
        playerStat = gameObject.GetComponent<playerStats>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        right = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Jumping == false)
        {
            if (rigidbody2d.velocity.x != 0)
            {
                animator.SetBool("Running", true);
            }
            else
            {
                animator.SetBool("Running", false);
            }
        }

        

        //DEAD

        if (gameObject.transform.position.y <= -10)
        {
            mainMenu.GameOver();
        }

    }

    void OnJumper()
    {

        Debug.Log("JUMP");

        //Jumping
        if (DoubleJump == false && Jumping == false)
        {
            Jumping = true;
            animator.SetBool("Running", false);
            animator.SetBool("Jumping", true);
            Jump();
        }

        if (Jumping == true)
        {
            if (jumpTimerCount > 0)
            {
                Jump();
                animator.SetBool("Jumping", true);
                animator.SetBool("Running", false);
                jumpTimerCount -= Time.deltaTime;
            }

        }

        if (Jumping == true && DoubleJump == false)
        {
            DoubleJump = true;
            Jump();
            rigidbody2d.AddForce(Vector2.up * 1.2f, ForceMode2D.Impulse);
        }
    }

    void Jump()
    {
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
        rigidbody2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D levelPass)
    {
        if (levelPass.gameObject.name == ("statue1"))
        {
            Debug.Log("triger");
            mainMenu.Level2();
        }

        if (levelPass.gameObject.name == ("statue2"))
        {
            mainMenu.Level3();
        }

        if (levelPass.gameObject.name == ("statue3"))
        {
            mainMenu.Level4();
        }

        if (levelPass.gameObject.name == ("statueEnd"))
        {
            Debug.Log("triger");
            mainMenu.MainMenuEnding();
        }

    }
    
    private void FixedUpdate()
    {
        CharacterMovement();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Jumping = false;
        isGrounded = true;
        DoubleJump = false;

        if (isGrounded == true)
        {
            jumpTimerCount = jumpTime;
            animator.SetBool("Jumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Jumping = true;
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        
    }
    void CharacterMovement()
    {
        if (rigidbody2d.velocity.x <= maxSpeed)
        {
            Vector2 movement = (moveInput * speed);
            rigidbody2d.AddForce ( movement);
        }
        
        if (rigidbody2d.velocity.x > 0)
        {
            if (left == true)
            {
                Player.GetComponent<SpriteRenderer>().flipX = false;
                left = false;
                right = true;
            }
        }

        if (rigidbody2d.velocity.x < 0)
        {
            if (right == true)
            {
                Player.GetComponent<SpriteRenderer>().flipX = true;
                right = false;
                left = true;
            }
        }
    }

    

    public void playerDefeated()
    {
        Debug.Log("defeated");
        mainMenu.GameOver();
        
    }
}
