using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 7f;
    public TMP_Text timerText;

    private bool timerRunning = true;

    void Start()
    {
        // Garante que o GameController é inicializado ao iniciar a cena de jogo.
        if (!GameController.gameOver)
        {
            GameController.Init();
            Debug.Log("GameController.Init() chamado via GameTimer");
        }
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerRunning = false;

                GameController.TimeRanOut();
                Debug.Log("⏰ Tempo esgotado! Fim de jogo.");
            }

            UpdateTimerDisplay();
        }
    }

    public void AddTime(float seconds)
    {
        timeRemaining += seconds;
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Tempo: " + Mathf.CeilToInt(timeRemaining).ToString() + "s";
    }

    public bool IsRunning()
    {
        return timerRunning;
    }
}
