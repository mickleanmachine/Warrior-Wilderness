using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private float speed = 10;
    private float jumpForce = 10;
    public float gravityModifier;
    private float leftborder = -7;
    private float rightborder = 11;
    public bool isOnGround = true;
    public Rigidbody2D playerRigidBody;
    

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
    }
    private void FixedUpdate()
    {

        MovePlayer();
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
            playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("you tried to jump");
            isOnGround = false;

        }
    }

    // this makes the player translate left and right based on arrow input
    void MovePlayer()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
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
    
    // i have prevented a double jump
    // i have set boundaries on the player movement area
    // i have set a rigid body component to the enemy
    // next i want to make a mele damage system 
    // goal is that when i press the "a" key, the enemy gets destroyed
    


}

