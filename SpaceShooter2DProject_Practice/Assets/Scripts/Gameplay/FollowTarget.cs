using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject targetToFollow;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetToFollow != null)
        {
            transform.position = targetToFollow.transform.position + offset;
        }
    }

    public void SetTargetToFollow(GameObject target)
    {
        offset = gameObject.transform.position - target.transform.position;
        targetToFollow = target;
    }
}
