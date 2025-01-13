using System.Collections;
using System.Collections.Generic;
using Joystick_Pack.Scripts.Base;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private bool moveLeft, moveRight;

    private bool IsSurface;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    /* 
    private void Update()
    {
        if (moveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        UpdateAnimationState();
    }

    */

    //keyboard input

    private void Update()
    {
        
        // Horizontal movement
        
        if (moveLeft || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            dirX = -1;
        }
        else if (moveRight || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            dirX = 1;
        }
        else
        {
            // Stop horizontal movement when no key is pressed
            rb.velocity = new Vector2(0f, rb.velocity.y);
            dirX = 0;
        }

        // Jump input (Space or Up Arrow)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }


    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("surface"))
        {
            IsSurface = true;
        }
    }

    
    public void JumpPlayer()
    {
        if (IsGrounded() | IsSurface == true)
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
 
    public void MoveLeft()
    {
        moveLeft = true;
        dirX = -1;
    }

    public void MoveRight()
    {
        moveRight = true;
        dirX = 1;
    }
    
    public void StopMoving()
    {
        moveRight = false;
        moveLeft = false;
        rb.velocity = new Vector2(0f, rb.velocity.y); // Preserve vertical velocity
        dirX = 0;
    }
   

    /*
    public void StopMoving()
    {
        moveRight = false;
        moveLeft = false;
        rb.velocity = Vector2.zero;
        dirX = 0;
    }
    */

    /*
    private void Update()
    {
        // Using GetKey to check for continuous input while key is held down
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        if (moveLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (moveRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        UpdateAnimationState();
    }

    private void Update()
    {
        // Direct input handling without moveLeft/moveRight variables
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        UpdateAnimationState();
    }

    */


}
