using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private float gravityModifier = 3;
    private float rightborder = 11;
    private float leftborder = -7;
    private float jumpForce = 10;
    private float speed = 10;
    private int numberOfAirJumps = 0;
    private int maxAirJumps = 1;
    public bool isOnGround = true;
    public Rigidbody2D playerRigidBody;
    public Animator animator;

    

    // Start is called before the first frame update
    void Start()
    {
        // this collects the rigid body component of the spirte its attached to so that you can add forces to it 
        playerRigidBody = GetComponent<Rigidbody2D>();

        //this adjusts the gravity so that the jumping is a little more fluid
        Physics2D.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        PlayerAttack();
    }
    private void FixedUpdate()
    {
        PlayerHorizontalMovement();
        PlayerContraints();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this checks to see if the player is touching the ground before they hit jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    // this makes the player jump
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            numberOfAirJumps = 0;
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            isOnGround = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnGround==false && numberOfAirJumps < maxAirJumps)
        {
            numberOfAirJumps = 1;
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            Debug.Log("Air jump");
        }
    }

    // this makes the player translate left and right based on arrow input
    void PlayerHorizontalMovement()
    {
        if (Input.GetKey("right"))
        {
            playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
        }
        else if (Input.GetKey("left"))
        {
            playerRigidBody.velocity = new Vector2(-speed, playerRigidBody.velocity.y);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
        }
        animator.SetFloat("Speed", playerRigidBody.velocity.magnitude);
    }
        //this sets the bounds of where the player can go
    void PlayerContraints()
    {
        if (transform.position.x < leftborder)
        {
            transform.position = new Vector2(leftborder, transform.position.y);
        }
        else if (transform.position.x > rightborder)
        {
            transform.position = new Vector2(rightborder, transform.position.y);
        }
    }

    void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Attack", true);
        }
        else //if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Attack", false);
        }
        //need to find out how to make to where the attack animation only plays once when i hit A button
    }
    
    


}

