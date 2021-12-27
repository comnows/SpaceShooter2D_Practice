using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBehavior_MovePass : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
    }
}
