using UnityEngine;

public class UIManagement : MonoBehaviour
{
    public GameObject endGamePanel;
    private bool panelShown = false;

    void FixedUpdate()
    {
        if (!panelShown && GameController.gameOver)
        {
            Debug.Log("🎮 Game Over detectado pelo UIManagement!");

            // Zera o score atual ao ocorrer Game Over
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.ResetScore();
            }

            endGamePanel.SetActive(true);
            panelShown = true;
        }
    }
}
