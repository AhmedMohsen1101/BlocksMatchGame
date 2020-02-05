using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone : MonoBehaviour
{
    public bool isEmpty = true;
    public Color blockColor;
    public Vector2 Location;

    public void SetLocation(int width, int height)
    {
        Location = new Vector2(width, height);
    }
    public Vector2 GetLocation()
    {
        return Location;
    }
    public void SetBlockColor(Color c)
    {
        blockColor = c;
    }
    public Color GetBlockColor()
    {
        return blockColor;
    }
}
