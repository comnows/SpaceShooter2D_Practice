using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player Spaceship");

        float posDiffX = player.transform.position.x - gameObject.transform.position.x;
        float posDiffY = player.transform.position.y - gameObject.transform.position.y;

        float angleToPlayer = Mathf.Atan2(posDiffY, posDiffX) * Mathf.Rad2Deg;
        gameObject.transform.eulerAngles = new Vector3(0, 0, angleToPlayer);
    }
}
