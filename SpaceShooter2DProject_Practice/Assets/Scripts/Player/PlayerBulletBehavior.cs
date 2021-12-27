using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D bulletRB;
    [SerializeField] GameObject hitEffectObj;

    public int bulletDamage = 1;
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyProperties enemyProperties = other.GetComponent<EnemyProperties>();

            if(enemyProperties != null)
            {
                enemyProperties.Update_EnemyHealth(-bulletDamage);
            }

            GameObject hitVFX = Instantiate(hitEffectObj, transform.position, Quaternion.identity);

            FollowTarget followTarget = hitVFX.GetComponent<FollowTarget>();
            
            if(followTarget != null)
            {
                followTarget.SetTargetToFollow(other.gameObject);
            }
            
            Destroy(gameObject);
        }
    }
}
