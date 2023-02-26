using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    //Tags: Player, SpeedUp, WidePaddle, ShrinkPaddle
    public GameObject currentPlayer = null, previousPlayer = null;

    //List of Powerups to spawn and the current powerups in play
    public List<GameObject> PowerUpList = new List<GameObject>();
    public List<GameObject> CurrentPowerUpList = new List<GameObject>();

    //keeping track of powerups
    int MaximumNumberOfPowerups = 4;
    int CurrentNumberOfPowerups = 0;

    
    void Start()
    {
        //Waits 1 sec to start repeating method every 3 secs
        InvokeRepeating("PowerupSpawner", 1.0f, 3.0f);
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
                CurrentNumberOfPowerups--;
                break;
            case "SpeedUp":
                gameObject.GetComponent<Ball>().SpeedUpBall();
                Destroy(a.gameObject);
                CurrentNumberOfPowerups--;
                break;
            case "ReverseControls":
                //gameObject.GetComponent<Paddles>().reverseControls();
                currentPlayer.GetComponent<Paddles>().reverseControls();
                Destroy(a.gameObject);
                CurrentNumberOfPowerups--;
                break;
        }
    }

    //Gets rid of all powerups in play
    public void Reset()
    {
        foreach(GameObject powerup in CurrentPowerUpList)
        {
            Destroy(powerup);
        }

        CurrentNumberOfPowerups = 0;
    }

    //Spawns random powerup within random set range
    void PowerupSpawner()
    {
        Vector2 SpawnLocation = new Vector2(Random.Range(-5f, 5f), Random.Range(3f, -3));
        if (CurrentNumberOfPowerups < MaximumNumberOfPowerups)
        {
            CurrentPowerUpList.Add(Instantiate(PowerUpList[Random.Range(0, PowerUpList.Count)], SpawnLocation, this.transform.rotation));

            CurrentNumberOfPowerups++;
        }
    }
}
