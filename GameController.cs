using UnityEngine;

public static class GameController
{
    // Se quiser manter o controle de colecionáveis para pontuação, pode deixar,
    // mas para condição de Game Over usaremos somente o tempo.
    private static int collectableCount;
    private static bool started = false;
    private static bool timeOver = false;

    // Game Over agora depende somente de quando o tempo acabar.
    public static bool gameOver
    {
        get { return started && timeOver; }
    }

    public static void Init()
    {
        collectableCount = 0;
        started = true;
        timeOver = false;
        Debug.Log("GameController initialized: started = true, timeOver = false");
    }

    public static void Collect()
    {
        collectableCount--;
    }

    public static void SpawnedNewItem()
    {
        collectableCount++;
    }

    public static void ForceGameOver()
    {
        collectableCount = 0;
    }

    public static void TimeRanOut()
    {
        timeOver = true;
    }
}
