using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private float speed = 10;
    private float jumpForce = 10;
    private Rigidbody2D playerRigidBody;
    public float gravityModifier;
    public bool isOnGround = true;
    

    // Start is called before the first frame update
    void Start()
    {
        // this collects the rigid body component of the spirte its attached to 
        // so that you can add forces to it 
        
        playerRigidBody = GetComponent<Rigidbody2D>();

        //this adjusts the gravity so that the jumping is a little more fluid
        
        Physics2D.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // this makes the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("you tried to jump");
            isOnGround = false;
           
        }
    }
    private void FixedUpdate()
    {
        // this makes the player translate left and right based on arrow input
        transform.Translate(Vector2.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        
    }

    // so as of know im working on preventing the double jump
    // i can jump once and then isOnGround gets set to false but then doesnt go back
    
       
}

