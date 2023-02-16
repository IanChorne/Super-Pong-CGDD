using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    private int leftScore;
    private int rightScore;

    public void LeftPlayerScored()
    {
        leftScore++;
        leftText.GetComponent<TextMeshProUGUI>().text = leftScore.ToString();
        ResetPosition();
    }

    public void RightPlayerScored()
    {
        rightScore++;
        rightText.GetComponent<TextMeshProUGUI>().text = rightScore.ToString();
        ResetPosition();
    }
    
    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        leftPaddle.GetComponent<Paddles>().Reset();
        rightPaddle.GetComponent<Paddles>().Reset();
        ball.GetComponent<PowerupManager>().Reset();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
