
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public TMP_Text winnerText;

    [Header("Board")]
    public string[] board = new string[9];
    public Transform[] cells = new Transform[9];
    public GameObject markPrefab;

    [Header("Game State")]
    public string currentPlayer = "X";
    public bool gameOver = false;
    public int moveCount = 0;

    private bool gameStarted = false;
    private TMP_Text[] markTexts = new TMP_Text[9];

    void Start()
    {
        // Create marks inside all cells
        for (int i = 0; i < cells.Length; i++)
        {
            GameObject mark = Instantiate(markPrefab, cells[i]);

            markTexts[i] = mark.GetComponentInChildren<TMP_Text>();

            if (markTexts[i] == null)
            {
                Debug.LogError("TMP Text missing in Mark Prefab!");
                continue;
            }

            markTexts[i].text = "";
        }

        // Initial UI
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);

        Debug.Log("Game Initialized!");
    }

    // START GAME
    public void StartGame()
    {
        ResetBoard();

        gameStarted = true;

        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        Debug.Log("Game Started!");
    }

    // MAKE MOVE
    public void MakeMove(int index)
    {
        if (!gameStarted || gameOver)
            return;

        if (index < 0 || index >= 9)
            return;

        if (!string.IsNullOrEmpty(board[index]))
            return;

        board[index] = currentPlayer;
        markTexts[index].text = currentPlayer;

        moveCount++;

        Debug.Log(currentPlayer + " played at cell " + index);

        // Check winner
        if (CheckWinner())
        {
            gameOver = true;

            winnerText.text = currentPlayer + " Wins !!";

            gameOverPanel.SetActive(true);

            Debug.Log(currentPlayer + " WINS!");

            return;
        }

        // Check draw
        if (moveCount == 9)
        {
            gameOver = true;

            winnerText.text = "It's a Draw!";

            gameOverPanel.SetActive(true);

            Debug.Log("GAME DRAW!");

            return;
        }

        // Switch player
        currentPlayer = currentPlayer == "X" ? "O" : "X";

        Debug.Log("Next Player: " + currentPlayer);
    }

    // WINNER DETECTION
    bool CheckWinner()
    {
        int[,] combinations =
        {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},

            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},

            {0, 4, 8},
            {2, 4, 6}
        };

        for (int i = 0; i < 8; i++)
        {
            int a = combinations[i, 0];
            int b = combinations[i, 1];
            int c = combinations[i, 2];

            if (!string.IsNullOrEmpty(board[a]) &&
                board[a] == board[b] &&
                board[b] == board[c])
            {
                return true;
            }
        }

        return false;
    }

    // REMATCH
    public void Rematch()
    {
        ResetBoard();

        gameStarted = true;

        gameOverPanel.SetActive(false);

        Debug.Log("Rematch Started!");
    }

    // STOP GAME
    public void StopGame()
    {
        ResetBoard();

        gameStarted = false;

        gameOverPanel.SetActive(false);
        startPanel.SetActive(true);

        Debug.Log("Game Stopped!");
    }

    // RESET BOARD
    void ResetBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            board[i] = "";
            markTexts[i].text = "";
        }

        currentPlayer = "X";
        moveCount = 0;
        gameOver = false;
    }
}
