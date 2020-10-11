using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptForPlayerHorizontalMovement : MonoBehaviour
{

    [SerializeField]  float speed = 10;
    float gravityModifier = 100;
    public Rigidbody2D playerRigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        //Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        //playerRigidBody.AddForce(Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        //playerRigidBody.velocity = Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //playerRigidBody.MovePosition((Vector2)transform.position + (Vector2.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime));
        PlayerHorizontalMovement();
        
    }

    void PlayerHorizontalMovement()
    {
        if (Input.GetKey("right"))
        {
            Debug.Log("Right button pressed");
            playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
        }
        else if (Input.GetKey("left"))
        {
            Debug.Log("Left button pressed");
            playerRigidBody.velocity = new Vector2(-speed, playerRigidBody.velocity.y);
        }
        else
        {
            Debug.Log("not moving");
            playerRigidBody.velocity = new Vector2(0, playerRigidBody.velocity.y);
        }
    }
}
