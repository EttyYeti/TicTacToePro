using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPlayerXTurn = true;
    public List<Button> tileButtons;

    void Start()
    {
        foreach (Button btn in tileButtons)
        {
            btn.onClick.AddListener(() => OnTileClicked(btn));
        }
    }

    void OnTileClicked(Button clickedButton)
    {
        // Get the TextMeshPro component inside the button
        TextMeshProUGUI tmp = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null)
        {
            tmp.text = isPlayerXTurn ? "X" : "O";
        }

        clickedButton.interactable = false; // Disable button
        isPlayerXTurn = !isPlayerXTurn;     // Switch turns

        // (Later) Call win/draw check here
    }
}
