using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptForPlayerJumping : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    [SerializeField] private float jumpForce = 3;
    [SerializeField] private float gravityModifier = 1;
    private int numberOfAirJumps = 0;
    private int maxAirJumps = 1;
    public bool isOnGround = true;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        playerJumpController();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this checks to see if the player is touching the ground before they hit jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    void playerJumpController()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            numberOfAirJumps = 0;
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            isOnGround = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnGround == false && numberOfAirJumps < maxAirJumps)
        {
            //playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            numberOfAirJumps = 1;
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
            Debug.Log("Air jump");
        }
    }
}
