using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_properties : MonoBehaviour
{
    // VARIABLES
    // Load GameObject bullet into script
    public GameObject bullet;

    // Load Rigidbody2D bullet into script
    public Rigidbody2D body; 

    // Load Firepoint
    public GameObject firepoint;

    // Projectile lifetime
    public float lifetime;

    // Clock
    public float clock;

    // Projectile speed
    public float speed;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        // Set lifetime
        lifetime = 2f;
        // Set speed
        speed = 9f;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase clock time
        clock += Time.deltaTime;

        // Move the projectile
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Deactivate bullet after lifetime expired
        if (lifetime < clock)
        {
            deactivate();
        }
    }

    // If the projectile hits somethign it deactivates
    private void OnCollisionEnter2D(Collision2D collision)
    {
        deactivate();
    }

    void deactivate()
    {
        // Deactivate bullet
        bullet.SetActive(false);

        // Reset clock
        clock = 0f;
    }
}
