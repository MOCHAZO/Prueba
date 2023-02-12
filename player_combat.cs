using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_combat : MonoBehaviour
{
    // VARIABLES
    // Projectile list
    public List<GameObject> projectile_list = new List<GameObject>();

    // Import player GameObject
    public GameObject player;

    // Import Firepoint
    public GameObject firepoint;

    // Attack Cooldown, minimu is set in powerup_attack
    public float attack_cd;

    // Clock
    private float clock;

    //PRUEBA
    // Import laser sound
    public AudioSource laser_sound;
    public AudioSource enemy_death;


    // Start is called at the start
    private void Start()
    {
        // Set Variables
        attack_cd = 1f;

        //PRUEBA
        // Volume of the laser sound
        laser_sound.volume = 0.20f;
        enemy_death.volume = 0.20f;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase clock time
        clock += Time.deltaTime;

        // Attack automatically
        if (attack_cd <= clock)
        {
            search_Projectil();
        }
    }


    // FUNCTIONS
    public void search_Projectil()
    {
        // Check bullet list for innactive bullets
        foreach (GameObject item in projectile_list)
        {
            // Play laser sound when shooting
            laser_sound.Play();
            if (item.gameObject.activeInHierarchy == false)
            {
                // Activate an innactive bullet
                item.gameObject.SetActive(true);

                // Move the bullet to the player's firepoint
                item.transform.position = firepoint.transform.position;

                // Rotate the projectile to face the same direction than the player's firepoint
                item.transform.rotation = firepoint.transform.rotation;

                // Reset Clock
                clock = 0f;
                return;
            }
        }
        // If no bullets were found
        Debug.Log("No stored bullets available");
    }

    //PRUEBA
    public void playEnemyDeathSound()
    {
        enemy_death.Play();
    }
}
