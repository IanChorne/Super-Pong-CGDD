using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{
    public bool isLeftPaddle;
    public Rigidbody2D rb;
    public float speed = 7;
    private float movement;
    private float spawner;
    public Vector3 startPosition;
    public Vector3 initialSize;

    public GameObject spawnPoint;

    bool reverse = false;

    //variables for sticky paddle
    public string leftPlayer = "Vertical";
    public string rightPlayer = "Vertical2";
    public bool sticky = false;
    public bool ballstuck = false;
    public float verticalBallspeed;
    public float horizontalBallspeed;
    public int stickyLimit = 3;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftPaddle == true)
        {
            if (reverse)
            {
                movement = -Input.GetAxisRaw("Vertical");
            }
            else
            {
                movement = Input.GetAxisRaw("Vertical");
            }

            if(spawnPoint.transform.position.x > -1)
            {
                spawnPoint.transform.position = new Vector2(-1, transform.position.y);
            }
            else if(spawnPoint.transform.position.x < -7)
            {
                spawnPoint.transform.position = new Vector2(-7, transform.position.y);
            }
            else if (spawnPoint.transform.position.x >= -7 && spawnPoint.transform.position.x <= -1)
            {
                spawnPoint.transform.position = new Vector2(spawnPoint.transform.position.x + Input.GetAxisRaw("Horizontal") * 0.02f, transform.position.y);
            }
        }
        if (isLeftPaddle == false)
        {
            if (reverse)
            {
                movement = -Input.GetAxisRaw("Vertical2");
            }
            else
            {
                movement = Input.GetAxisRaw("Vertical2");
            }
            if (spawnPoint.transform.position.x < 1)
            {
                spawnPoint.transform.position = new Vector2(1, transform.position.y);
            }
            else if (spawnPoint.transform.position.x > 7)
            {
                spawnPoint.transform.position = new Vector2(7, transform.position.y);
            }
            else if (spawnPoint.transform.position.x <= 7 && spawnPoint.transform.position.x >= 1)
            {
                spawnPoint.transform.position = new Vector2(spawnPoint.transform.position.x + Input.GetAxisRaw("Horizontal2") * 0.02f, transform.position.y);
            }
        }
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
   
        //code that controls activating the sticky power for their respective players
        if(isLeftPaddle && Input.GetKeyDown(KeyCode.F))
        {
            StickyPowers(leftPlayer);
        }
        else if(!isLeftPaddle && Input.GetKeyDown(KeyCode.RightControl))
        {
            StickyPowers(rightPlayer);
        }
    }

    //code for the sticky paddle powerup
    public void StickyPowers(string controls)
    {
        //ball will detach from the paddle and shoot the ball
        if(sticky == true && ballstuck == true && movement != 0)
        {
            GameObject child = this.gameObject.transform.GetChild(0).gameObject;
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            child.transform.parent = null;
            
            //control the direction of the y vector depending which way the paddle moves
            if(movement < 0)
            {
                child.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalBallspeed, -verticalBallspeed);
            }
            else if(movement > 0)
            {
                child.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalBallspeed, verticalBallspeed);
            }

            sticky = false;
            stickyLimit--;
        }
        //active that sticky powers
        else if(sticky == false && stickyLimit > 0)
        {
            sticky = true;
        }
    }

    //when the sticky paddle powerup is active the ball stick to the paddle
    void OnCollisionEnter2D(Collision2D o)
    {
        float xPosition = o.gameObject.transform.position.x;
        //the ball will become the child of the paddle it collides with so that the ball will move with the paddle
        //the 7.7 is to set the boundary of where the ball can stick since there were issues of the ball getting stuck at the bottom and top of the paddles
        if (sticky == true && o.gameObject.tag == "Ball" && (xPosition > -7.7 && xPosition < 7.7))
        {
            CalculateSpeed(o.gameObject.GetComponent<Rigidbody2D>().velocity);
            o.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            o.gameObject.transform.parent = this.gameObject.transform;
            o.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            ballstuck = true;
        }
    }

    //calculate the vector so the ball will launch at a 45 degree angles so the x and y vector should be the same number
    public void CalculateSpeed(Vector2 speed)
    {
        float angleInRadian = Mathf.PI/4;
        
        //calculate the hypotenuse
        float vectorSpeed = Mathf.Sqrt(Mathf.Pow(speed.x, 2f) + Mathf.Pow(speed.y, 2f));

        //calcute the x and y of the vector
        verticalBallspeed = vectorSpeed * Mathf.Sin(angleInRadian);
        horizontalBallspeed = verticalBallspeed;

        //for the x vector depending on if the paddle is the left or right
        if (isLeftPaddle == false)
        {
            horizontalBallspeed *= -1;
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        transform.localScale = initialSize;
        reverse = false;
        sticky = false;
        ballstuck = false;
        stickyLimit = 3;
    }

    //Added by Ian in branch ReverseControls
    public void reverseControls()
    {
        if (!reverse){ reverse = true; }else { reverse = false; }
    }

}
