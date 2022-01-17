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
    [SerializeField] GameObject muzzlePrefabs;
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] GameObject bulletSpawnPoint;

    [SerializeField] int firingDamage = 1;
    [SerializeField] float firingMoveSpeed = 1.0f;
    [SerializeField] float firingRate = 1.0f;

    //float spawnTimer = 0.0f;
    float NextTimeToFire = 0.0f;

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
            NextTimeToFire = Time.time + 1.0f / (firingRate * (1 + (PlayerStat.instance.firingRateUpgradeLevel * 0.2f)));

            if(PlayerStat.instance.currentFiringType == FiringType.Normal)
            {
                SpawnPlayerBullet_Normal();
            }
            else if(PlayerStat.instance.currentFiringType == FiringType.Spread3)
            {
                SpawnPlayerBullet_Spread3();
            }
            else if(PlayerStat.instance.currentFiringType == FiringType.Straight3)
            {
                SpawnPlayerBullet_Straight3();
            }
        }
    }

    void SpawnPlayerBullet_Normal()
    {
        GameObject spawnedMuzzle = Instantiate(muzzlePrefabs, bulletSpawnPoint.transform.position - new Vector3(.5f, 0f, 0f), Quaternion.identity);
        GameObject spawnedBullet = Instantiate(bulletPrefabs);
        spawnedBullet.transform.position = bulletSpawnPoint.transform.position;

        SetSpawnedBullet(spawnedBullet);
    }

    void SpawnPlayerBullet_Spread3()
    {
        float currentBulletAngle = -15.0f;
        float angleIncreasePerBullet = 15.0f;

        float muzzleScale = 2f;

        GameObject spawnedMuzzle = Instantiate(muzzlePrefabs, bulletSpawnPoint.transform.position - new Vector3(.5f, 0f, 0f), Quaternion.identity);
        spawnedMuzzle.transform.localScale = new Vector3(muzzleScale, muzzleScale, muzzleScale);
        
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
        float muzzlePosOffset = .2f;

        float currentBulletPosY = -0.45f;
        float posIncreasePerBullet = 0.45f;

        for(int bulletCount = 0; bulletCount < 3; bulletCount++)
        {
            GameObject spawnedMuzzle = Instantiate(muzzlePrefabs, bulletSpawnPoint.transform.position - new Vector3(.7f, 0f, 0f), Quaternion.identity);
            spawnedMuzzle.transform.position += new Vector3(muzzlePosOffset * Mathf.Pow(-1,bulletCount + 1), currentBulletPosY + (posIncreasePerBullet * bulletCount), 0);

            GameObject spawnedBullet = Instantiate(bulletPrefabs);
            spawnedBullet.transform.position = bulletSpawnPoint.transform.position;
            spawnedBullet.transform.position += new Vector3(0, currentBulletPosY + (posIncreasePerBullet * bulletCount), 0);

            SetSpawnedBullet(spawnedBullet);
        }
    }

    void SetSpawnedBullet(GameObject targetBullet)
    {
        targetBullet.transform.localScale = targetBullet.transform.localScale * (1.0f + (PlayerStat.instance.firingSizeUpgradeLevel / 5.0f));

        PlayerBulletBehavior PBBehavior = targetBullet.GetComponent<PlayerBulletBehavior>();
        if(PBBehavior != null)
        {
            PBBehavior.bulletDamage = firingDamage + PlayerStat.instance.firingDamageUpgradeLevel;
            PBBehavior.bulletMoveSpeed = firingMoveSpeed + (PlayerStat.instance.firingMoveSpeedUpgradeLevel * 2.5f);
        }
    }

    void Test_UpgradeSystem()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            PlayerStat.instance.firingDamageUpgradeLevel += 1;
            Debug.Log("Cheat Active : Increase firing damage by 1.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            PlayerStat.instance.firingMoveSpeedUpgradeLevel += 1;
            Debug.Log("Cheat Active : Increase firing movespeed by 1.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            PlayerStat.instance.firingRateUpgradeLevel += 1;
            Debug.Log("Cheat Active : Increase firing rate by 1.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            PlayerStat.instance.firingSizeUpgradeLevel += 1;
            Debug.Log("Cheat Active : Increase firing size by 1.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad7))
        {
            PlayerStat.instance.currentFiringType = FiringType.Normal;
            Debug.Log("Cheat Active : Change firing type to Normal.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad8))
        {
            PlayerStat.instance.currentFiringType = FiringType.Spread3;
            Debug.Log("Cheat Active : Change firing type to Spread3.");
        }

        if(Input.GetKeyDown(KeyCode.Keypad9))
        {
            PlayerStat.instance.currentFiringType = FiringType.Straight3;
            Debug.Log("Cheat Active : Change firing type to Straight3.");
        }
    }
}
