using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPlayerXTurn = true;
    public List<Button> tileButtons;
    public TextMeshProUGUI winMessageText;
    private string[] board = new string[9];

    void Start()
    {
         for (int i = 0; i < tileButtons.Count; i++)
        {
            int index = i; // capture index for closure
            tileButtons[i].onClick.AddListener(() => OnTileClicked(index));
        }
    }

    void OnTileClicked(int index)
    {
        if (board[index] != null)
            return;

        string currentPlayer = isPlayerXTurn ? "X" : "O";
        board[index] = currentPlayer;

        TextMeshProUGUI tmp = tileButtons[index].GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.text = currentPlayer;
        }

        tileButtons[index].interactable = false;
        if (CheckWin(currentPlayer))
        {
            Debug.Log(currentPlayer + " wins!");
            EndGame();
        }
        else if (CheckDraw())
        {
            Debug.Log("Draw!");
            EndGame();
        }
        else
        {
            isPlayerXTurn = !isPlayerXTurn;
        }
    }

    bool CheckWin(string player)
    {
        int[,] winPatterns = new int[,]
        {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // rows
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // columns
            {0, 4, 8}, {2, 4, 6}             // diagonals
        };

        for (int i = 0; i < winPatterns.GetLength(0); i++)
        {
            if (board[winPatterns[i, 0]] == player &&
                board[winPatterns[i, 1]] == player &&
                board[winPatterns[i, 2]] == player)
            {
                return true;
            }
        }

        return false;
    }

    bool CheckDraw()
    {
        foreach (string val in board)
        {
            if (string.IsNullOrEmpty(val))
                return false;
        }
        return true;
    }

    void EndGame()
    {
        // Disable all buttons
        foreach (var btn in tileButtons)
        {
            btn.interactable = false;
        }

        winMessageText.gameObject.SetActive(true);

        if (CheckDraw())
            winMessageText.text = "It's a Draw!";
        else
            winMessageText.text = (isPlayerXTurn ? "X" : "O") + " Wins!";
    }
}
