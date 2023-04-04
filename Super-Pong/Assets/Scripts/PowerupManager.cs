using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PowerupManager : MonoBehaviour
{
    //Tags: Player, SpeedUp, WidePaddle, ShrinkPaddle
    public GameObject currentPlayer = null, previousPlayer = null;

    //get PowerupSpawnManager
    public GameObject powerupSpawner;

    //Sound Effects
    public AudioClip aWide, aSmall, aSpeed, aReverse;

    //Boolean that tells wether the paddle is extended
    public bool isExtended = false;

    void OnCollisionEnter2D(Collision2D o)
    {
        if (o.gameObject.GetComponent<AudioSource>())
        {
            o.gameObject.GetComponent<AudioSource>().Play();
        }

        //When the ball hits a paddle
        //Saves the paddle that last hit the ball as the currentPlayer
        if (o.gameObject.tag == "Player")
        {
            previousPlayer = currentPlayer;
            currentPlayer = o.gameObject;
        }
        
    }

    //Activates the powerups and gets rid of them
    void OnTriggerEnter2D(Collider2D a)
    {
        switch (a.gameObject.tag)
        {
            case "WidePaddle":
                isExtended = true;
                currentPlayer.transform.localScale = new Vector3(0.25f, 3f, 1f);
                Destroy(a.gameObject);
                PlaySound(aWide);
                powerupSpawner.GetComponent<PowerupSpawnManager>().CurrentNumberOfPowerups--;
                break;
            case "SmallPaddle":
                if(isExtended)
                {
                    previousPlayer.transform.localScale = new Vector3(0.25f, 2f, 1f);
                    isExtended = false;
                }
                if(!isExtended)
                {
                    previousPlayer.transform.localScale = new Vector3(0.25f, 1f, 1f);
                }
                Destroy(a.gameObject);
                PlaySound(aSmall);
                powerupSpawner.GetComponent<PowerupSpawnManager>().CurrentNumberOfPowerups--;
                break;
            case "SpeedUp":
                gameObject.GetComponent<Ball>().SpeedUpBall();
                Destroy(a.gameObject);
                PlaySound(aSpeed);
                powerupSpawner.GetComponent<PowerupSpawnManager>().CurrentNumberOfPowerups--;
                break;
            case "ReverseControls":
                //gameObject.GetComponent<Paddles>().reverseControls();
                previousPlayer.GetComponent<Paddles>().reverseControls();
                Destroy(a.gameObject);
                PlaySound(aReverse);
                powerupSpawner.GetComponent<PowerupSpawnManager>().CurrentNumberOfPowerups--;
                break;
        }
    }

    void PlaySound(AudioClip soundEffect)
    {
        this.gameObject.GetComponent<AudioSource>().clip = soundEffect;
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}


/*
 if(Extended)
    paddle size = default
else
    paddle size = small
 */