using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{
    public bool isLeftPaddle;
    public Rigidbody2D rb;
    public float speed = 5;
    private float movement;
    public Vector3 startPosition;
    public Vector3 initialSize;

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
            movement = Input.GetAxisRaw("Vertical");
        }
        if (isLeftPaddle == false)
        {
            movement = Input.GetAxisRaw("Vertical2");   
        }
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);

        if(reverse == true)
        {
            reverseControls();
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        transform.localScale = initialSize;
    }

    //Added by Ian in branch ReverseControls
    public bool reverseControls()
    {
        reverse = true;
        if (isLeftPaddle == true)
        {
            movement = -Input.GetAxisRaw("Vertical");
        }
        if (isLeftPaddle == false)
        {
            movement = -Input.GetAxisRaw("Vertical2");
        }
        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        return true;
    }

}
