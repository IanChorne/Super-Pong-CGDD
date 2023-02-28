using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnManager : MonoBehaviour
{
    //List of Powerups to spawn and the current powerups in play
    public List<GameObject> PowerUpList = new List<GameObject>();
    public List<GameObject> CurrentPowerUpList = new List<GameObject>();

    //keeping track of powerups
    public int MaximumNumberOfPowerups = 4;
    public int CurrentNumberOfPowerups = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Waits 1 sec to start repeating method every 3 secs
        InvokeRepeating("PowerupSpawner", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gets rid of all powerups in play
    public void Reset()
    {
        foreach (GameObject powerup in CurrentPowerUpList)
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
