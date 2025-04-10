using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public GameObject endGameMenu;

    public void StartGame()
    {
        // Reseta o score antes de iniciar a cena do jogo
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetScore();
        }
        GameController.Init();
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
