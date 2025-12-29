using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] TMP_Text scoreText;
    int score = 0;
    public void AddScore(int amount)
    {
        //if(timeManager.IsGameOver()) return;
        if (timeManager.IsGameOver) return;

        score += amount;
        scoreText.text = score.ToString();
    }
}
