using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector3 speed;
    public float height;
    public float pound;
    public float sprint;
    public int jumpTimes;
    public int maxJump = 2;
    private Vector3 thisPos;

    // Start is called before the first frame update
    void Start()
    {
        thisPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpTimes < maxJump)
            {
             rb.AddForce(Vector3.up * height);
                ++jumpTimes;
                Debug.Log("Jumped: " + jumpTimes);
            }
           
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.AddForce(Vector3.down * pound);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed.x = speed.x + sprint;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed.x = speed.x - sprint;
        }

        if(transform.position.x > 217)
        {
            transform.position = thisPos;
            speed.x = speed.x + 0.015f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        jumpTimes = 0;
        Debug.Log("Jump Refreshed");
    }
}
