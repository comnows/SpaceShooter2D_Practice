using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
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
        
        if(transform.position.x <= -10.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            GameObject hitVFX = Instantiate(hitEffectObj, transform.position, Quaternion.identity);

            FollowTarget followTarget = hitVFX.GetComponent<FollowTarget>();
            
            if(followTarget != null)
            {
                followTarget.SetTargetToFollow(other.gameObject);
            }

            PlayerProperties playerProperties = other.gameObject.GetComponent<PlayerProperties>();

            if(playerProperties != null)
            {
                PlayerStat.instance.Update_PlayerHealth(-bulletDamage);
            }
            
            Destroy(gameObject);
        }
    }
}
