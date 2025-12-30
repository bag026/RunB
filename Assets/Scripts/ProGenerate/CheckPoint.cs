using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float checkpointtimeIncrease = 5f;
    [SerializeField] float obsstacleDecreaseTimeAmount = 0.2f;
    TimeManager timeManager;
    ObstocleSpawn obstocleSpawn;
    const string playerString = "Player";
    private void Start() {
        timeManager = FindFirstObjectByType<TimeManager>();
        obstocleSpawn = FindFirstObjectByType<ObstocleSpawn>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerString))
        {
            timeManager.IncreaseTime(checkpointtimeIncrease);
            obstocleSpawn.DecreseObsticleSpawnTime(obsstacleDecreaseTimeAmount);
            
        }
    }

}
