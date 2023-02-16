using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    //Tags: Player, SpeedUp, WidePaddle, ShrinkPaddle
    
    public GameObject currentPlayer = null, previousPlayer = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D o)
    {
        //When the ball hits a paddle
        //Saves the paddle that last hit the ball as the currentPlayer
        if(o.gameObject.tag == "Player")
        {
            previousPlayer = currentPlayer;
            currentPlayer = o.gameObject;
        }
    }

    //activates the powerups
    void OnTriggerEnter2D(Collider2D a)
    {
        switch(a.gameObject.tag)
        {
            case "WidePaddle":
                currentPlayer.transform.localScale = new Vector2(0.25f, 3f);
                Destroy(a.gameObject);
                break;
            case "SpeedUp":
                break;
            case "ReverseControl":
                break;
        }
    }
}
