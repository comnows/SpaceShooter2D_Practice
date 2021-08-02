using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FiringType
{
    Normal = 1,
    Spread3 = 2,
    Straight3 = 3
}

public class PlayerFiringSystem : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] GameObject bulletSpawnPoint;

    [SerializeField] float firingDamage = 1.0f;
    [SerializeField] float firingMoveSpeed = 1.0f;
    [SerializeField] float firingRate = 1.0f;

    FiringType currentFiringType = FiringType.Normal;

    //float spawnTimer = 0.0f;
    float NextTimeToFire = 0.0f;

    int firingDamageUpgradeLevel = 0;
    int firingMoveSpeedUpgradeLevel = 0;
    int firingRateUpgradeLevel = 0;
    int firingSizeUpgradeLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Test_UpgradeSystem();

        /*spawnTimer += Time.deltaTime;

        if(spawnTimer >= firingRate)
        {
            SpawnPlayerBullet();
            spawnTimer = 0.0f;
        }*/

        if(Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1.0f / (firingRate * (1 + (firingRateUpgradeLevel * 0.25f)));

            if(currentFiringType == FiringType.Normal)
            {
                SpawnPlayerBullet_Normal();
            }
            else if(currentFiringType == FiringType.Spread3)
            {
                SpawnPlayerBullet_Spread3();
            }
            else if(currentFiringType == FiringType.Straight3)
            {
                SpawnPlayerBullet_Straight3();
            }
        }
    }

    void SpawnPlayerBullet_Normal()
    {
        GameObject spawnedBullet = Instantiate(bulletPrefabs);
        spawnedBullet.transform.position = bulletSpawnPoint.transform.position;

        SetSpawnedBullet(spawnedBullet);
    }

    void SpawnPlayerBullet_Spread3()
    {
        float currentBulletAngle = -15.0f;
        float angleIncreasePerBullet = 15.0f;
        for(int bulletCount = 0; bulletCount < 3; bulletCount++)
        {
            GameObject spawnedBullet = Instantiate(bulletPrefabs);
            spawnedBullet.transform.position = bulletSpawnPoint.transform.position;

            spawnedBullet.transform.eulerAngles = new Vector3(0, 0, currentBulletAngle + (angleIncreasePerBullet * bulletCount));

            SetSpawnedBullet(spawnedBullet);
        }
    }

    void SpawnPlayerBullet_Straight3()
    {
        float currentBulletPosY = -0.4f;
        float posIncreasePerBullet = 0.4f;
        for(int bulletCount = 0; bulletCount < 3; bulletCount++)
        {
            GameObject spawnedBullet = Instantiate(bulletPrefabs);
            spawnedBullet.transform.position = bulletSpawnPoint.transform.position;
            spawnedBullet.transform.position += new Vector3(0, currentBulletPosY + (posIncreasePerBullet * bulletCount), 0);

            SetSpawnedBullet(spawnedBullet);
        }
    }

    void SetSpawnedBullet(GameObject targetBullet)
    {
        targetBullet.transform.localScale = targetBullet.transform.localScale * (1.0f + (firingSizeUpgradeLevel / 5.0f));

        PlayerBulletBehavior PBBehavior = targetBullet.GetComponent<PlayerBulletBehavior>();
        if(PBBehavior != null)
        {
            PBBehavior.bulletDamage = firingDamage + firingDamageUpgradeLevel;
            PBBehavior.bulletMoveSpeed = firingMoveSpeed + (firingMoveSpeedUpgradeLevel * 2.5f);
        }
    }

    void Test_UpgradeSystem()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            firingDamageUpgradeLevel += 1;
            Debug.Log("Cheat Active : Increase firing damage by 1.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            firingMoveSpeedUpgradeLevel += 1;
            Debug.Log("Cheat Active : Increase firing movespeed by 1.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            firingRateUpgradeLevel += 1;
            Debug.Log("Cheat Active : Increase firing rate by 1.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            firingSizeUpgradeLevel += 1;
            Debug.Log("Cheat Active : Increase firing size by 1.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad7))
        {
            currentFiringType = FiringType.Normal;
            Debug.Log("Cheat Active : Change firing type to Normal.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad8))
        {
            currentFiringType = FiringType.Spread3;
            Debug.Log("Cheat Active : Change firing type to Spread3.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad9))
        {
            currentFiringType = FiringType.Straight3;
            Debug.Log("Cheat Active : Change firing type to Straight3.");
        }
    }
}