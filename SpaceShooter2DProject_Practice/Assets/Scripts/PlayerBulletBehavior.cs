using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRB;
    public float bulletDamage = 1.0f;
    public float bulletMoveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletRB.velocity = transform.right * bulletMoveSpeed;
        
        if(transform.position.x >= 10.0f)
        {
            Destroy(gameObject);
        }
    }

    
}
