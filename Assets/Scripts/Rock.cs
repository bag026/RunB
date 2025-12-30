using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource collisionAudioSource;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float collisionCooldown = 1f;
    CinemachineImpulseSource cinemachineimpulseSource;
    float collisionTimer = 1f;
    private void Awake() {
        cinemachineimpulseSource = GetComponent<CinemachineImpulseSource>();
    }
    void Update()
    {
        collisionTimer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < collisionCooldown) return;
        
        FirePause();
        CollisionFX(other);
        collisionTimer = 0f;
        
    }
    
    

    private void FirePause()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        cinemachineimpulseSource.GenerateImpulse(shakeIntensity);
    }
    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        collisionAudioSource.Play();

        
    }
}
