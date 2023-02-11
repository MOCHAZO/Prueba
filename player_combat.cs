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

    // Attack Cooldown
    public float attack_cd = 1f;

    // Clock
    public float clock;


    private void Start()
    {
        // Set attack cooldown
        attack_cd = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase clock time
        clock += Time.deltaTime;

        // Attack automatically
        if (attack_cd <= clock)
        {
            search_Proyectil();
        }
    }


    // FUNCTIONS
    public void search_Proyectil()
    {
        // Check bullet list for innactive bullets
        foreach (GameObject item in projectile_list)
        {
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

                break;
            }
        }
    }
}
