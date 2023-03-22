using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingManager : MonoBehaviour
{
    public List<GameObject> wallListLeft;
    public List<GameObject> wallListRight;

    public List<GameObject> spawnedWalls;

    public GameObject prefabWall;

    public GameObject LeftSpawnPoint;
    public GameObject RightSpawnPoint;

    void Update()
    {
        //Checks left player if they can spawn walls
        if (wallListLeft.Count > 0)
        {
            //Spawns wall in list by pressing shift
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                spawnedWalls.Add(Instantiate(wallListLeft[0], new Vector2(LeftSpawnPoint.transform.position.x, LeftSpawnPoint.transform.position.y), Quaternion.identity));
                
                wallListLeft.RemoveAt(0);
            }
        }

        if(wallListRight.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                spawnedWalls.Add(Instantiate(wallListLeft[0], new Vector2(RightSpawnPoint.transform.position.x, RightSpawnPoint.transform.position.y), Quaternion.identity));

                wallListRight.RemoveAt(0);
            }
        }
    }

    public void ResetWalls()
    {
        //resets walls and adds five walls to each player's list
        foreach (GameObject wall in spawnedWalls)
        {
            Destroy(wall);
        }

        wallListLeft.Clear();
        wallListRight.Clear();
        
        for (int i = 0; i < 5; i++)
        {
            wallListLeft.Add(prefabWall);
            wallListRight.Add(prefabWall);
        }
    }
}
