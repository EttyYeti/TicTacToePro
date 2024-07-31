using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    public Sprite[] images;

    // Awake is called to 'initialize' all game components
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //0 is left click
            {
                Debug.Log("Left click");
                spriteRenderer.sprite = images[1];
            }
    }

}
