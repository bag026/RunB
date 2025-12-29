using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score = 0;
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
