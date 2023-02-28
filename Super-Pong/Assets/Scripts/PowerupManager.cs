using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    //Tags: Player, SpeedUp, WidePaddle, ShrinkPaddle
    public GameObject currentPlayer = null, previousPlayer = null;

    //get PowerupSpawnManager
    public GameObject powerupSpawner;

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

    //Activates the powerups and gets rid of them
    void OnTriggerEnter2D(Collider2D a)
    {
        switch(a.gameObject.tag)
        {
            case "WidePaddle":
                currentPlayer.transform.localScale = new Vector3(0.25f, 3f, 1f);
                Destroy(a.gameObject);
                powerupSpawner.GetComponent<PowerupSpawnManager>().CurrentNumberOfPowerups--;
                break;
            case "SpeedUp":
                gameObject.GetComponent<Ball>().SpeedUpBall();
                Destroy(a.gameObject);
                powerupSpawner.GetComponent<PowerupSpawnManager>().CurrentNumberOfPowerups--;
                break;
            case "ReverseControls":
                //gameObject.GetComponent<Paddles>().reverseControls();
                currentPlayer.GetComponent<Paddles>().reverseControls();
                Destroy(a.gameObject);
                powerupSpawner.GetComponent<PowerupSpawnManager>().CurrentNumberOfPowerups--;
                break;
        }
    }
}
