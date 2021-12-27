using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownBehavior : MonoBehaviour
{
    [SerializeField] float minMoveDistance = -1.0f;
    [SerializeField] float maxMoveDistance = 1.0f;

    float moveDistance = 0.0f;
    float randomOffsetTime = 0.0f;
    float startPosition_Y = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        randomOffsetTime = Random.Range(-1000.0f, 1000.0f);
        moveDistance = Random.Range(minMoveDistance, maxMoveDistance);
        startPosition_Y = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float movingDistance_Y = Mathf.Sin(Time.realtimeSinceStartup + randomOffsetTime) * moveDistance;
        Vector3 currentPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector3(currentPosition.x, startPosition_Y + movingDistance_Y, currentPosition.z);
    }
}
