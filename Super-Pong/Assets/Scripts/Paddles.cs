using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{
    public bool isLeftPaddle;
    public Rigidbody2D rb;
    public float speed = 5;
    private float movement;
    private float spawner;
    public Vector3 startPosition;
    public Vector3 initialSize;

    public GameObject spawnPoint;

    bool reverse = false;

    //variables for sticky paddle
    //public GameObject ball;
    public string leftPlayer = "Vertical";
    public string rightPlayer = "Vertical2";
    public bool sticky = false;
    public bool ballstuck = false;

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
                spawnPoint.transform.position = new Vector2(spawnPoint.transform.position.x + Input.GetAxisRaw("Horizontal") * 0.01f, transform.position.y);
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
                spawnPoint.transform.position = new Vector2(spawnPoint.transform.position.x + Input.GetAxisRaw("Horizontal2") * 0.01f, transform.position.y);
            }
        }
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
   
        //Testing child and parent object
        if(isLeftPaddle && Input.GetKeyDown(KeyCode.F))
        {
            StickyPowers(leftPlayer);
        }
        else if(!isLeftPaddle && Input.GetKeyDown(KeyCode.RightControl))
        {
            StickyPowers(rightPlayer);
        }
    }

    public void StickyPowers(string controls)
    {
        //ball will detach from the paddle and shoot the ball
        if(sticky == true && ballstuck == true)
        {
            GameObject child = this.gameObject.transform.GetChild(0).gameObject;
            child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            child.transform.parent = null;
        }
        //active that sticky powers
        else if(sticky == false)
        {
            sticky = true;
        }
    }

    void OnCollisionEnter2D(Collision2D o)
    {
        //the ball will become the child of the paddle it collides with so that the ball will move with the paddle
        if (sticky == true && o.gameObject.tag == "Ball")
        {
            o.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            o.gameObject.transform.parent = this.gameObject.transform;
            o.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            ballstuck = true;
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
    }

    //Added by Ian in branch ReverseControls
    public void reverseControls()
    {
        if (!reverse){ reverse = true; }else { reverse = false; }
    }

}
