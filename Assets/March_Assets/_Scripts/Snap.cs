using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Snap : MonoBehaviour, ISnappable
{

    private SpriteRenderer[] sprites;
    private void Start()
    {
        sprites = this.gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingOrder = 1;
        }
        Debug.Log(sprites.Length);
    }
    public bool IsThisSnapZoneEmpty()
    {
        throw new System.NotImplementedException();
    }

    private void OnMouseDown()
    {
        OnSnappingBegin();
    }
    private void OnMouseDrag()
    {
        MoveWithMousePoistion();
        OnSnapping();
    }
   
    private void OnMouseUp()
    {
        OnSnapped();
    }
    public void OnSnappingBegin()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingOrder = 10;
        }
        this.gameObject.transform.localScale *= 0.75f;
    }
    public void OnSnapping()
    {

        
    }
    public void OnSnapped()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingOrder = 1;
        }
        this.gameObject.transform.localScale /= 0.75f;
    }

    private void MoveWithMousePoistion()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePosition;
    }
}
