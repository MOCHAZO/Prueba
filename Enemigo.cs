using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{

    public Transform PlayerToFollow = null;
    public float Speed = 2;

    // Start is called before the first frame update

    private void Awake()
    {
        PlayerToFollow = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //TAGEA AL PLAYER CON ADD TAG -> NEW -> ''Player'' , sino no funcionara
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerToFollow == null)
            return;
        transform.position = Vector2.MoveTowards(transform.position, PlayerToFollow.transform.position, Speed * Time.deltaTime);
        transform.up = PlayerToFollow.position - transform.position;
    }

    /*public void Finish()
    {
        gameObject.
        //if(playerLife == 0)
        SceneManager.LoadScene("Lose");


    }*/
}
