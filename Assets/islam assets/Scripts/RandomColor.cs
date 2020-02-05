using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomColor : MonoBehaviour
{
    private Color[] colors =  
    {
        new Color(255, 0, 0),
        new Color(255, 255, 0),
        new Color(0, 255, 0),
        new Color(255, 110, 0),
    };
    private Color blockColor;
    private SpriteRenderer spriteRenderer;
    void OnEnable()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        SetBlockColor();
    }
    public void SetBlockColor ()
    {
        for (int i = 0; i < 4; i++)
        {
            int colorNumber = Random.Range(0, colors.Length);
            blockColor = colors[colorNumber];
            spriteRenderer.color = colors[colorNumber];
        }
    }
    public Color GetColor()
    {
        return blockColor;
    }
}
