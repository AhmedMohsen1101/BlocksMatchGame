using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour, ISnappable
{
    private SpriteRenderer[] sprites;
    RaycastHit2D[] hits;

    private bool onSnapping = false;
    private bool snapable;
    private void Start()
    {
        sprites = this.gameObject.GetComponentsInChildren<SpriteRenderer>();

        //Setup the Layer Renderering order
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingOrder = 2;
        }
    }
    private void FixedUpdate()
    {

        if (onSnapping)
        {
            RaycastFromEveyBlock();
            CheckRaycasts();
        }
    }

    private void OnMouseDown()
    {
        OnSnappingBegin();
    }
    private void OnMouseDrag()
    {
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
        this.gameObject.transform.localScale = new Vector2(0.75f, 0.75f);

    }
    public void OnSnapping()
    {
        onSnapping = true;
        MoveWithMousePosition();
    }
    public void OnSnapped()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sortingOrder = 2;
        }
        this.gameObject.transform.localScale = new Vector2(1, 1);
        onSnapping = false;
    }

    private void MoveWithMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePosition;
    }

    //CheckTileWithRaycast for every box in the shape
    private void RaycastFromEveyBlock()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            hits = Physics2D.RaycastAll(sprites[i].transform.position, -sprites[i].transform.forward, 5f);
        }
    }

    private bool CheckRaycasts()
    {
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.tag != "Tile")
            {
                return false;
            }
            else
            {
                Debug.Log("All tile are empty! u can span now");
                return true;
            }
        }
        return false;
    }

    private void SnapObject()
    {

    }

    private void UnsnapObject()
    {

    }
}
