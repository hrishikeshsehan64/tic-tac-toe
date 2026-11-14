
using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{
    public int cellIndex;

    public GameManager gameManager;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        if (button == null)
        {
            Debug.LogError("Button component missing!");
            return;
        }

        if (gameManager == null)
        {
            Debug.LogError("GameManager not assigned!");
            return;
        }

        button.onClick.AddListener(HandleClick);
    }

    void HandleClick()
    {
        Debug.Log("BUTTON CLICKED: " + cellIndex);

        gameManager.MakeMove(cellIndex);
    }

    void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(HandleClick);
        }
    }
}
