using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosYAtStart : MonoBehaviour
{
    [SerializeField] float minRandY = -2.0f;
    [SerializeField] float maxRandY = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        float randomAddY = Random.Range(minRandY, maxRandY);
        gameObject.transform.position += new Vector3 (0, randomAddY, 0);
    }
}
