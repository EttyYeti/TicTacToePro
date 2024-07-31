using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    GameObject gameBoard;
    public Sprite[] images;

    // Awake is called to 'initialize' all game components
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameBoard = GameObject.Find("Board");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        int index = gameBoard.GetComponent<GameScript>().PlayerTurn();
        spriteRenderer.sprite = images[1];
    }

}
