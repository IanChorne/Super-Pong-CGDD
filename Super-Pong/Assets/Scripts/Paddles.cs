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
   
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        transform.localScale = initialSize;
        reverse = false;
    }

    //Added by Ian in branch ReverseControls
    public void reverseControls()
    {
        if (!reverse){ reverse = true; }else { reverse = false; }
    }

}
