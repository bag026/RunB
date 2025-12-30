using System;
using System.Collections;
using UnityEngine;

public class ObstocleSpawn : MonoBehaviour
{
    [SerializeField]  GameObject[] obstaclePrefabs;
    [SerializeField]  float obstacleSpawnTime = 1f;
    [SerializeField] float minobstacleSpawnTime = .2f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
        
    }
    public void DecreseObsticleSpawnTime(float amount)
    {
        obstacleSpawnTime -= amount;
        if(obstacleSpawnTime <= minobstacleSpawnTime)
        {
            obstacleSpawnTime = minobstacleSpawnTime;
        }
    }
    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[UnityEngine.Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3( UnityEngine.Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition, UnityEngine.Random.rotation, obstacleParent);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
