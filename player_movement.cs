using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // VARIABLES
    // Player movement speed
    public float speed;

    // Player x & y inputs
    private float xInput;
    private float yInput;

    // Rigidbody load for player model
    public Rigidbody2D body;

    // Start is called once at the start
    private void Start()
    {
        // Set Variables
        speed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets a value for the key inputs
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        // Movement of the player
        body.velocity = new Vector2(xInput * speed, yInput * speed);

        // Player looks at the mouse
        look_Mouse();
    }

    // FUNCTIONS
    public void look_Mouse() {
        // Get mouse position in camera
        Vector3 mousePosition = Input.mousePosition;

        // Convert to world units
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Vector that subtracts the player position to the mouse position
        // Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        // Moves the player in the Y axis based on the pointing vector
        transform.up = direction;
    }
}
