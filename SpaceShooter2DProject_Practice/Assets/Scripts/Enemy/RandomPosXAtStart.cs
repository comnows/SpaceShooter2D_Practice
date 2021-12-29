using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosXAtStart : MonoBehaviour
{
    [SerializeField] float minRandX = -2.0f;
    [SerializeField] float maxRandX = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        float randomAddX = Random.Range(minRandX, maxRandX);
        gameObject.transform.position += new Vector3 (randomAddX, 0, 0);
    }
}
