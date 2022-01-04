using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject EnemySpawnPoint;
    [SerializeField] GameObject[] EnemyPatternList;

    [SerializeField] bool usingOnTestList = false;
    [SerializeField] GameObject[] EnemyPatternList_OnTest;

    List<GameObject> OnPlayEnemyList;

    // Start is called before the first frame update
    void Start()
    {
        OnPlayEnemyList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int index = 0; index < OnPlayEnemyList.Count; index++)
        {
            GameObject currentEnemyOnPlay = OnPlayEnemyList[index];

            if(currentEnemyOnPlay != null)
            {
                if(currentEnemyOnPlay.transform.position.x < -20.0f)
                {
                    Destroy(currentEnemyOnPlay);
                    OnPlayEnemyList.RemoveAt(index);
                    index -= 1;
                }
            }
            else
            {
                OnPlayEnemyList.RemoveAt(index);
                index -= 1;
            }
        }

        if(OnPlayEnemyList.Count == 0)
        {
            Random_SpawnEnemyPattern();
        }
    }

    private void Random_SpawnEnemyPattern()
    {
        GameObject enemyPatternObj = null;

        if(!usingOnTestList)
        {
            int randomPatternIndex = Random.Range(0, EnemyPatternList.Length);
            enemyPatternObj = Instantiate(EnemyPatternList[randomPatternIndex], EnemySpawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            int randomPatternIndex = Random.Range(0, EnemyPatternList_OnTest.Length);
            enemyPatternObj = Instantiate(EnemyPatternList_OnTest[randomPatternIndex], EnemySpawnPoint.transform.position, Quaternion.identity);
        }

        OnPlayEnemyList.Add(enemyPatternObj);
    }
}
