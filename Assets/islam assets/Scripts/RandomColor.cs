using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Sprite[] imageList = new Sprite[4];
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetBlockColor();

    }
    public void SetBlockColor ()
    {
        int colorNumber;
        colorNumber = Random.Range(0, 3);
        sr.sprite = imageList[colorNumber ];


    }
}
