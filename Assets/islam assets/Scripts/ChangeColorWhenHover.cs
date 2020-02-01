using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorWhenHover : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool isEmpty = true;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnMouseExit()
    {
        SetBlockColor();

    }
    private void OnMouseEnter()
    {
        Setoriginalcolor();

    }
    //private void OnMouseOver()
    //{
    //}
    public void SetBlockColor ()
    {
        sr.color = default;
    }
    public void Setoriginalcolor()
    {
        if (isEmpty)
        {
            //change color to green
            sr.color = new Color(0, 1, 0, 1);
        }
        else if (!isEmpty)
        {
            //change color to red
            sr.color = new Color(1, 0, 0, 1);

        }
    }
}
