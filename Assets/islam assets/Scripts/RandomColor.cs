﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomColor : MonoBehaviour
{
    private Color[] colors =  
    {
        new Color(255, 0, 0),
        new Color(255, 255, 0),
        new Color(0, 255, 0),
        new Color(0, 0, 255),
    };

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        //spriteRenderer.rendererPriority = 1;
        SetBlockColor();
    }
    public void SetBlockColor ()
    {
        for (int i = 0; i < 4; i++)
        {
            int colorNumber = Random.Range(0, 3);
            spriteRenderer.color = colors[colorNumber];
        }
    }
}