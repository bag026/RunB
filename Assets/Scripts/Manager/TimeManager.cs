using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;


    [SerializeField] float startTime = 5f;
    float timeLeft;
    bool isGameOver = false;
    
    void Start()
    {
        timeLeft = startTime;
    }
    void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (isGameOver) return;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
        if (timeLeft <= 0f)
        {
            Gameover();
        }

    }

    void Gameover()
    {
        isGameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
