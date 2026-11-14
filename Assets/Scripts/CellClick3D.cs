
using UnityEngine;

public class CellClick3D : MonoBehaviour
{
    public int cellIndex;

    public GameManager gameManager;

    void OnMouseDown()
    {
        // Check GameManager reference
        if (gameManager == null)
        {
            Debug.LogError("GameManager not assigned to " + gameObject.name);
            return;
        }

        // Stop clicking after game ends
        if (gameManager.gameOver)
        {
            Debug.Log("Game is already over!");
            return;
        }

        // Send the clicked cell index to GameManager
        Debug.Log("3D CELL CLICKED: " + cellIndex);

        gameManager.MakeMove(cellIndex);
    }
}
