using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mov : MonoBehaviour
{
    // VARIABLES
    // Value for horizontal input
    private float horizontalInput;

    // Marks if the player is midair
    private bool midair = true;

    // Speed values for movement calculations
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 3f;

    // To assign the player object physics and the script
    [SerializeField] private Rigidbody2D body;

    //-------

    // UPDATE
    void Update()
    {
        // Takes the horizontal input from the player
        horizontalInput = Input.GetAxis("Horizontal");

        // Moves the player left or right depending on his speed and input
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Checks when the players presses space and modifies vertical velocity if he is not in midair
        if (Input.GetKeyDown(KeyCode.Space) == true && midair == false)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.A) == true){
            transform.localScale = new Vector3(-2f, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.D) == true)
        {
            transform.localScale = new Vector3(2f, transform.localScale.y, transform.localScale.z);
        }
    }

    //-------

    // FUNCTIONS
    // Function that makes the player jump wen called
   private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        midair = true;
    }

    //-------

    // Checks if the player is colliding with the ground to set the midair tag to false
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            midair = false;
        }
    }
}
