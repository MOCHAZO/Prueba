using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_hp : MonoBehaviour
{
    // VARIABLES
    // Player Hp
    public float hp;

    // Boolean that checks true when the player is colliding
    private bool colliding;

    // Player Invulnerability time after taking dmg
    public float inv_time;

    // Display player's hp
    public Text hp_text;

    // Clock
    private float clock;

    // PRUEBA
    // Death sound
    public AudioSource death_sound;
    // Hit sound
    public AudioSource hit_sound;

    // Start is called before the first frame update
    void Start()
    {
        // Set variables
        hp = 3f;
        inv_time = 1f;
        colliding = false;

        //PRUEBA
        death_sound.volume = 0.1f;
        hit_sound.volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase clock
        clock += Time.deltaTime;

        // Player takes constant damage if it's colliding with something
        if (inv_time < clock && colliding == true)
        {
            hit_sound.Play();
            hp -= 1;
            // Updates HP display
            hp_text.text = $"{hp}";
            
            // If player reaches 0 hp, trigger GameOver screen
            if (hp <= 0)
            {
                //SceneManager.LoadScene("Lose");

                // PRUEBA
                death_sound.Play();
                Debug.Log("Player Loses");
                
            }
            
            // Reset the clock
            clock = 0f;
        }
    }

    // COLLISIONS
    // Turn colliding to true when player collides
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Power")
        {
            colliding = true;
            Debug.Log("true");
        }
    }

    // Turn colliding to false when player collides
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Power")
        {
            colliding = false;
            Debug.Log("false");
        }
    }
}
