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

    //public bool IsGameOver{get { return isGameOver; }}
    //public bool IsGameOver { get; private set; }
    public bool IsGameOver => isGameOver;
    
    void Start()
    {
        timeLeft = startTime;
    }
    void Update()
    {
        DecreaseTime();
    }
    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }
   
    void DecreaseTime()
    {
        if (isGameOver) return;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }

    }

    void PlayerGameOver()
    {
        isGameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
