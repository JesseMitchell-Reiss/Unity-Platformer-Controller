using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public bool grounded = false;

    [SerializeField, Range(0, 0.25f)]
    public float acceltime = 0;
    [SerializeField, Range(0, 0.25f)]
    public float deceltime = 0;
    [SerializeField, Range(0, 15)]
    public float speed = 0;
    [SerializeField, Range(0, 10)]
    public float jump = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetButtonDown("Jump") && grounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jump);
        }
    }

    void Move()
    {
        float dist = Input.GetAxis("Horizontal");
        if(dist != 0)
        {
            if(playerRB.velocity.x < speed && dist > 0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x + speed / acceltime * Time.deltaTime, playerRB.velocity.y);
            }
            else if(playerRB.velocity.x > -speed && dist<0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x - speed / acceltime * Time.deltaTime, playerRB.velocity.y);
            }
        }
        else
        {
            if(playerRB.velocity.x > 0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x - speed / deceltime * Time.deltaTime, playerRB.velocity.y);
            }
            else if(playerRB.velocity.x < 0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x + speed / deceltime * Time.deltaTime, playerRB.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
