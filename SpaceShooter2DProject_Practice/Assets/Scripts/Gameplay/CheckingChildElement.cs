using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingChildElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.childCount == 0)
        {
            gameObject.transform.position = new Vector3(-30, 0, 0);
        }
    }
}
