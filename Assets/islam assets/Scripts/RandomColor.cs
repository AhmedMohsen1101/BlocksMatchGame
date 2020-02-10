using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor
{
    Black,
    Red,
    Green,
    Yellow,
    Orange,
}
public class RandomColor : MonoBehaviour
{
    public BlockColor blockColor;
    public Color[] colors;    
    public Color currentColor;
    private SpriteRenderer spriteRenderer;
    void OnEnable()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        SetBlockColor();
    }
    public void SetBlockColor ()
    {
        int colorNumber = Random.Range(0, colors.Length);
        currentColor = colors[colorNumber];
        if(colorNumber == 0)
        {
            blockColor = BlockColor.Red;
        }
        else if (colorNumber == 1)
        {
            blockColor = BlockColor.Yellow;
        }
        else if (colorNumber == 2)
        {
            blockColor = BlockColor.Green;
        }
        else if (colorNumber == 2)
        {
            blockColor = BlockColor.Orange;
        }
        spriteRenderer.color = colors[colorNumber];
    }
}
