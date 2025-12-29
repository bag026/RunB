using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coins : Pickup
{
    [SerializeField] int scoreAmount = 100;
    ScoreManager scoreManager;
     public void Init(ScoreManager scoreManager) {
        this.scoreManager = scoreManager;
    }
    // Start iscalled once before the first execution of Update after the MonoBehaviour is created

    protected override void OnPickup()
    {
        scoreManager.AddScore(scoreAmount);
       
    }
}
