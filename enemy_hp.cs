using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp : MonoBehaviour
{
    // VARIABLES
    // Player Hp
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        // Set variables
        hp = 3f;
    }

    // COLLISIONS
    // Take damage only when colliding with a bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            hp -= 1;
        }
    }
}
