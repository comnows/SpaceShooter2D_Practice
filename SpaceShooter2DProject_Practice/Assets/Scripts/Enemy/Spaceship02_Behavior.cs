using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship02_Behavior : MonoBehaviour
{
    [SerializeField] float targetPositionX = 7.75f;
    float startPositionX = 0.0f;
    float startPositionY = 0.0f;
    float moveToPositionTime = 1.0f;
    float moveTimer = 0.0f;

    [SerializeField] float moveUpDownDistance = 3.5f;

    bool finishMoveToPosition = false;
    float timeWhenMoveToPositionFinish = 0.0f;
    float randomMoveUpDownDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToPosition());

        startPositionY = gameObject.transform.position.y;

        int randomDirection = Random.Range(0, 2);

        if(randomDirection == 0)
        {
            randomMoveUpDownDirection = 1;
        }
        else
        {
            randomMoveUpDownDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(finishMoveToPosition)
        {
            Vector3 currentPosition = gameObject.transform.position;
            float currentWorkTime = Time.realtimeSinceStartup - timeWhenMoveToPositionFinish;
            float nextPositionY = startPositionY + (Mathf.Sin(currentWorkTime) * moveUpDownDistance * randomMoveUpDownDirection);
            gameObject.transform.position = new Vector3(currentPosition.x, nextPositionY,currentPosition.z);
        }
    }

    IEnumerator MoveToPosition()
    {
        startPositionX = gameObject.transform.position.x;
        float distanceToTarget = targetPositionX - startPositionX;

        while(moveTimer < moveToPositionTime)
        {
            Vector3 currentPosition = gameObject.transform.position;
            float timerPercent = moveTimer / moveToPositionTime;
            float nextPositionX = startPositionX + (distanceToTarget * timerPercent);
            gameObject.transform.position = new Vector3(nextPositionX, currentPosition.y, currentPosition.z);

            moveTimer += Time.deltaTime;
            yield return null;
        }

        if(moveTimer >= moveToPositionTime)
        {
            Vector3 currentPosition = gameObject.transform.position;
            float timerPercent = moveTimer / moveToPositionTime;
            float nextPositionX = startPositionX + distanceToTarget;
            gameObject.transform.position = new Vector3(nextPositionX, currentPosition.y, currentPosition.z);

            finishMoveToPosition = true;
            timeWhenMoveToPositionFinish = Time.realtimeSinceStartup;
        }
    }
}
