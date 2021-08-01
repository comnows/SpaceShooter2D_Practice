using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement_ButtonPressed();
    }

    void Movement_ButtonPressed()
    {
        Vector2 sumVelocity = new Vector2(0, 0);
        
        if(Input.GetButton("MoveUp"))
        {
            sumVelocity += new Vector2(0, moveSpeed);
        }

        if(Input.GetButton("MoveDown"))
        {
            sumVelocity += new Vector2(0, -moveSpeed);
        }

        if(Input.GetButton("MoveLeft"))
        {
            sumVelocity += new Vector2(-moveSpeed, 0);
        }

        if(Input.GetButton("MoveRight"))
        {
            sumVelocity += new Vector2(moveSpeed, 0);
        }

        playerRB.velocity = sumVelocity;
    }
}
