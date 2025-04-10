using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int score = 0;
    public int highScore = 0;
    public TMP_Text scoreText;

    void Awake()
    {
        // Padrão Singleton para ter apenas uma instância
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Quando uma nova cena carrega, atualiza a referência do scoreText se necessário
        if (scoreText == null)
        {
            GameObject scoreObj = GameObject.FindGameObjectWithTag("ScoreText");
            if (scoreObj != null)
            {
                scoreText = scoreObj.GetComponent<TMP_Text>();
            }
        }
        UpdateScoreDisplay();
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (score > highScore)
        {
            highScore = score;
        }
        UpdateScoreDisplay();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score + "  |  High Score: " + highScore;
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
