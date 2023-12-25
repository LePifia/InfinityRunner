using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] float PlayerDistance_Spawn_Level;
    [SerializeField] GameObject player;

    [SerializeField]  Transform StartPosition;
    [SerializeField]  List <Transform> LevelList;

    private Vector3 lastEndPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        
        lastEndPosition = StartPosition.Find("EndPosition").transform.position;

        int StartingLevelParts = 3;

        for (int i = 0; i < StartingLevelParts; i++)
        {
            SpawnLevelPart();
        }
        
        

    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position,lastEndPosition) < PlayerDistance_Spawn_Level)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = LevelList[Random.Range(0, LevelList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);

        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform LevelPart ,Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(LevelPart, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }
}
