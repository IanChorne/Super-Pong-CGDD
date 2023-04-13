using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("SpawnManager")]
    public GameObject spawnManager;

    [Header("WallManager")]
    public GameObject wallManager;

    [Header("Ball")]
    public GameObject ball;

    [Header("Left Player")]
    public GameObject leftPaddle;
    public GameObject leftGoal;

    [Header("Right Player")]
    public GameObject rightPaddle;
    public GameObject rightGoal;

    [Header("Score UI")]
    public GameObject leftText;
    public GameObject rightText;

    public int leftScore;
    public int rightScore;

    private void Start()
    {
        leftScore = PlayerPrefs.GetInt("LeftPlayerScore");
        rightScore = PlayerPrefs.GetInt("RightPlayerScore");
        rightText.GetComponent<TextMeshProUGUI>().text = rightScore.ToString();
        leftText.GetComponent<TextMeshProUGUI>().text = leftScore.ToString();
    }

    public void LeftPlayerScored()
    {
        leftScore++;
        PlayerPrefs.SetInt("LeftPlayerScore", leftScore);
        leftText.GetComponent<TextMeshProUGUI>().text = leftScore.ToString();
        ResetPosition();
    }

    public void RightPlayerScored()
    {
        rightScore++;
        PlayerPrefs.SetInt("RightPlayerScore", rightScore);
        rightText.GetComponent<TextMeshProUGUI>().text = rightScore.ToString();
        ResetPosition();
    }
    
    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        leftPaddle.GetComponent<Paddles>().Reset();
        rightPaddle.GetComponent<Paddles>().Reset();
        spawnManager.GetComponent<PowerupSpawnManager>().Reset();
        wallManager.GetComponent<BaseBuildingManager>().ResetWalls();
    }
    

    // Update is called once per frame
    void Update()
    {
        // Win condition
        if (leftScore >= 11)
        {
            PlayerPrefs.SetInt("LeftPlayerScore", 0);
            PlayerPrefs.SetInt("RightPlayerScore", 0);
            SceneManager.LoadScene(5);
        }
        if (rightScore >= 11)
        {
            PlayerPrefs.SetInt("LeftPlayerScore", 0);
            PlayerPrefs.SetInt("RightPlayerScore", 0);
            SceneManager.LoadScene(4);
        }

        if (Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            //Application.Quit();
            SceneManager.LoadScene(6);
        }
    }
}
