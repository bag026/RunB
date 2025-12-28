using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollierHanlder : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangemoveSpeed = -2f;

    float cooldownTimer = 0f;
    const string hitTrigger = "Hit";
    LevelGenerator levelGenerator;
    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;
        levelGenerator.ChangeChunkMoveSpeed(adjustChangemoveSpeed);
        animator.SetTrigger(hitTrigger);
        cooldownTimer = 0f;
        
    }
   
}
