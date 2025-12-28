using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] float[] lanes = {-2.5f, 0f, 2.5f};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFences();
    }

    // Update is called once per frame
    void SpawnFences()
    {
        List<int> availableLanes = new List<int>{0,1,2};
        int fencesToSpawn = Random.Range(0, lanes.Length); // Spawn between 0 and 2 fences
        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count == 0) break;
            int randomLaneIndex = Random.Range(0, availableLanes.Count);
            int selectLane = availableLanes[randomLaneIndex];
            availableLanes.RemoveAt(randomLaneIndex);
            Vector3 spawnPosition = new Vector3(lanes[selectLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
        
    }
}
