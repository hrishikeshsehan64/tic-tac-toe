
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameManager gameManager;

    public void Rematch()
    {
        gameManager.Rematch();
    }

    public void StopGame()
    {
        gameManager.StopGame();
    }
}
