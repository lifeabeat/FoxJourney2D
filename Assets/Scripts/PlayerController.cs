using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    // Singleton
    public static PlayerController instance;


    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask whatisGround;
    [SerializeField]
    private Transform groundCheckPoint;
    [SerializeField]
    private Rigidbody2D theRB;
    public Rigidbody2D TheRB => theRB;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SpriteRenderer theSR;

    [SerializeField]
    private ParticleSystem jumpEffect;

    // Check Player on the ground
    private bool isGrounded;
    // Knockback
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    // Stomp on enemy head
    public float bounceForce;

    // When play touch levelend
    public bool stopInput;

    // Double Jump
    public bool canDoubleJump;

    //for Jump button
    private bool isJumping;
    private bool isNotDoubleJump;

    private enum MovementState { Idle, Running, Jumping, Falling }
    private MovementState movementState;

    private void Awake()
    {
        instance = this;
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.instance.isPause && !stopInput)
        {     
            if (knockBackCounter <= 0)
            {
                Moving();
                Jumping();
                UpdateAnimations();
            }
               else
               {
                      knockBackCounter -= Time.deltaTime;
                        if (!theSR.flipX)
                        {
                            theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
                        }
                        else
                        {
                            theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
                        }
               }
        }    
    }


    private void Moving()
    {
        /*theRB.velocity = new Vector2(moveSpeed * UIController.instance.variableJoystick.Direction.x, theRB.velocity.y);*/
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
    }

    private void Jumping()
    {


        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatisGround);

        // && !isjumping 
        // isJumping;

        if (isGrounded /*&& !isJumping*/)
        {
            canDoubleJump = true; 
        }

        
        if (Input.GetButtonDown("Jump"))
        /*if (isJumping)*/
        {
            if (isGrounded )
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                if (AudioManagerUpdateVer1.HasInstance)
                {
                    AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_PLAYERJUMP);
                }
               
            }
            else
            {
                if (canDoubleJump /*&& !isNotDoubleJump*/)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    if (AudioManagerUpdateVer1.HasInstance)
                    {
                        AudioManagerUpdateVer1.Instance.PlaySE(AUDIO.BGM_PLAYERJUMP);
                    }
                    jumpEffect.Play();
                    canDoubleJump = false;
                    
                }
            }
        }
    }    

    private void UpdateAnimations()
    {
        if (theRB.velocity.x < 0f)
        {
            theSR.flipX = true; // Trai
            movementState = MovementState.Running;
        }
        else if (theRB.velocity.x > 0f)
        {
            theSR.flipX = false; // Phai
            movementState = MovementState.Running;
        }
        else 
        {
            movementState = MovementState.Idle;
        }

        if (theRB.velocity.y > 0.1f)
        {
            movementState = MovementState.Jumping;
        }
        else if (theRB.velocity.y < -0.1f)
        {
            movementState = MovementState.Falling;

        }

        anim.SetInteger("State", (int)movementState);

    }    


    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);
        anim.SetTrigger("isHurt");
    }    

    public void Bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
    }    

    public void SetJump(bool value)
    {
        isJumping = value;
    }

    public void SetDoubleJump(bool value)
    {
        isNotDoubleJump = !value;
    }
}
