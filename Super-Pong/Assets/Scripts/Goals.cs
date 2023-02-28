using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
    public bool isLeftGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            this.gameObject.GetComponent<AudioSource>().Play();

            if (isLeftGoal)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().RightPlayerScored();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().LeftPlayerScored();
            }
        }
    }
}
