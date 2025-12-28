using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.5f;
    [SerializeField] float coinSeperationLength = 2f;
    [SerializeField] float[] lanes = {-2.5f, 0f, 2.5f};
    List<int> availableLanes = new List<int>{0,1,2};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    // Update is called once per frame
    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length); // Spawn between 0 and 2 fences
        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count == 0) break;
            int selectLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }

    }

    void SpawnApple()
    {
        if(Random.value > appleSpawnChance || availableLanes.Count <= 0) return;
        int selectLane = SelectLane();
        Vector3 spawnPosition = new Vector3(lanes[selectLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    
    }
    void SpawnCoins()
    {
        if(Random.value > coinSpawnChance || availableLanes.Count <= 0) return;
        int selectLane = SelectLane();
        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn);
        float topOfChunkZ = transform.position.z + (coinSeperationLength*2f);

        for (int i = 0; i < coinsToSpawn && i < maxCoinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZ - (i * coinSeperationLength);

            Vector3 spawnPosition = new Vector3(lanes[selectLane], transform.position.y, spawnPositionZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }
        
    }
    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectLane;
    }
}
