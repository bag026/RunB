using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] Button restartButton;
    [SerializeField] Button returnToMenuButton;



    [SerializeField] float startTime = 5f;
    float timeLeft;
    bool isGameOver = false;

    //public bool IsGameOver{get { return isGameOver; }}
    //public bool IsGameOver { get; private set; }
    public bool IsGameOver => isGameOver;
    
    void Start()
    {
        timeLeft = startTime;
        Time.timeScale = 1f;
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
        restartButton.gameObject.SetActive(true);
        returnToMenuButton.gameObject.SetActive(true);
        Time.timeScale = .1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
