using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float moveSpeed = 1.0f;

    public GameObject spaceshipJet;

    public float jetFullSpeedtime = .25f;
    public float jetIdleSize = 1f;
    float jetTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement_ButtonPressed();
        JetSize_Adjustment();
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

    private void JetSize_Adjustment()
    {
        float currentSpeed = playerRB.velocity.magnitude;

        if(currentSpeed == 0.0f)
        {
            jetTimer -= Time.deltaTime;
            jetTimer = Mathf.Clamp(jetTimer, 0, jetFullSpeedtime);
        }
        else
        {
            jetTimer += Time.deltaTime;
            jetTimer = Mathf.Clamp(jetTimer, 0, jetFullSpeedtime);
        }

        float jetTimerRatio = jetTimer / jetFullSpeedtime;
        float jetSize = Mathf.Clamp(2.0f * jetTimerRatio, 0, 1.5f);
        float finalJetSize = jetSize * jetTimerRatio;

        if(finalJetSize < jetIdleSize)
        {
            finalJetSize = jetIdleSize;
        }

        spaceshipJet.transform.localScale = new Vector3(1.5f, finalJetSize, 1.5f);
    }
}
