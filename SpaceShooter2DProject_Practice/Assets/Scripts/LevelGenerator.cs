using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject startLevelSet;
    [SerializeField] GameObject[] levelSetList;
    [SerializeField] float levelMovementSpeed = 5.0f;

    List<GameObject> levelOnPlayList;
    // Start is called before the first frame update
    void Start()
    {
        levelOnPlayList = new List<GameObject>();
        levelOnPlayList.Add(startLevelSet);
        CreateNewLevelSet();
    }

    // Update is called once per frame
    void Update()
    {
        Level_Movement();
        LevelGeneratorBehaviour();
    }

    void CreateNewLevelSet()
    {
        GameObject lastedLevelSet = levelOnPlayList[levelOnPlayList.Count - 1];
        GameObject connectionPoint = lastedLevelSet.transform.Find("LevelSet_ConnectPoint").gameObject;

        int randomLevelSetPattern = Random.Range(0, levelSetList.Length);
        GameObject newLevelSet = Instantiate(levelSetList[randomLevelSetPattern]);
        newLevelSet.transform.position = connectionPoint.transform.position;

        levelOnPlayList.Add(newLevelSet);
    }

    void Level_Movement()
    {
        for(int index = 0; index < levelOnPlayList.Count; index ++)
        {
            GameObject currentLevelSetInList = levelOnPlayList[index];
            currentLevelSetInList.transform.position += new Vector3(-levelMovementSpeed, 0, 0) * Time.deltaTime;
        }
    }

    void LevelGeneratorBehaviour()
    {
        GameObject firstLevelSetinList = levelOnPlayList[0];

        if(firstLevelSetinList.transform.position.x < -30.0f)
        {
            levelOnPlayList.RemoveAt(0);
            Destroy(firstLevelSetinList);
            CreateNewLevelSet();
        }
    }
}
