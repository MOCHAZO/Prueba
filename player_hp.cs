using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hp : MonoBehaviour
{
    public float hp;

    public float inv_time;

    public float clock;
    // Start is called before the first frame update
    void Start()
    {
        hp = 3f;
        inv_time = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (inv_time < clock)
        {
            hp -= 1;
            clock = 0f;
        }
        
    }
}
