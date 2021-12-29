using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiringBulletToPlayer : MonoBehaviour
{
    [SerializeField] GameObject muzzlePrefabs;
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] GameObject bulletSpawnPoint;

    [SerializeField] int firingDamage = 1;
    [SerializeField] float firingMoveSpeed = 1.0f;
    [SerializeField] float firingRate = 1.0f;

    FiringType currentFiringType = FiringType.Normal;

    float NextTimeToFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1.0f / firingRate;

            if(currentFiringType == FiringType.Normal)
            {
                SpawnEnemyBullet_Normal();
            }
            else if(currentFiringType == FiringType.Spread3)
            {
                
            }
            else if(currentFiringType == FiringType.Straight3)
            {
                
            }
        }
    }

    void SpawnEnemyBullet_Normal()
    {
        GameObject spawnedMuzzle = Instantiate(muzzlePrefabs, bulletSpawnPoint.transform.position, Quaternion.identity);
        GameObject spawnedBullet = Instantiate(bulletPrefabs);
        spawnedBullet.transform.position = bulletSpawnPoint.transform.position;

        SetSpawnedBullet(spawnedBullet);
    }

    void SetSpawnedBullet(GameObject targetBullet)
    {
        targetBullet.transform.localScale = targetBullet.transform.localScale;

        EnemyBulletBehavior PBBehavior = targetBullet.GetComponent<EnemyBulletBehavior>();
        if(PBBehavior != null)
        {
            PBBehavior.bulletDamage = firingDamage;
            PBBehavior.bulletMoveSpeed = firingMoveSpeed;
        }
    }
}
