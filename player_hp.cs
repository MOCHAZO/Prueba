using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hp : MonoBehaviour
{
    // VARIABLES
    // Player Hp
    public float hp;

    public bool colliding;

    // Player Invulnerability time after taking dmg
    public float inv_time;

    // Clock
    public float clock;

    // Start is called before the first frame update
    void Start()
    {
        // Set variables
        hp = 3f;
        inv_time = 1f;
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase clock
        clock += Time.deltaTime;

        // Player takes constant damage if it's colliding with something
        if (inv_time < clock && colliding == true)
        {
            hp -= 1;
            /*
            if (hp <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
            */
            clock = 0f;
        }
    }

    // COLLISIONS
    // Turn colliding to true when player collides
    private void OnCollisionEnter2D(Collision2D collision)
    {
        colliding = true;
    }

    // Turn colliding to false when player collides
    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }
}
