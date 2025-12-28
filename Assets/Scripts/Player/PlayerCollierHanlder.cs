using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollierHanlder : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    float cooldownTimer = 0f;
    const string hitTrigger = "Hit";

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer <= collisionCooldown) return;
        
        animator.SetTrigger(hitTrigger);
        cooldownTimer = 0f;
        
    }
   
}
