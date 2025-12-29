using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    [SerializeField] ParticleSystem SpeedupParticleSystem;
    [SerializeField] float minFOV = 20f;
    [SerializeField] float maxFOV = 120f;
    [SerializeField] float zoommDuration = 1f;
    [SerializeField] float zoomSpeedModifier = 5f;
    CinemachineCamera cinemachineCamera;
    private void Awake() {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }
    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOCRountine(speedAmount));
        if(speedAmount > 0)
        {
            SpeedupParticleSystem.Play();
        }
       
    }
    IEnumerator ChangeFOCRountine(float speedAmount)
    {
        float startFVO = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFVO + speedAmount * zoomSpeedModifier, minFOV, maxFOV);
        float elapsed = 0f;
        while (elapsed < zoommDuration)
        {

            float t = elapsed / zoommDuration;
            elapsed += Time.deltaTime;
            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFVO, targetFOV, t);
            yield return null;
        }
        cinemachineCamera.Lens.FieldOfView = targetFOV;

    }
}
