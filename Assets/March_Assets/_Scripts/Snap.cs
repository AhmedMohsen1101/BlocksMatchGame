using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Snap : MonoBehaviour, ISnappable
{ 
    public bool IsThisSnapZoneEmpty()
    {
        throw new System.NotImplementedException();
    }

    public void OnSnapped()
    {
        throw new System.NotImplementedException();
    }

    public void OnSnapping()
    {
        throw new System.NotImplementedException();
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");
    }
    private void OnMouseDrag()
    {
        Debug.Log("Draging");
        MoveWithMousePoistion();

    }
    private void MoveWithMousePoistion()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePosition;
    }
    private void OnMouseUp()
    {
        Debug.Log("Up");
    }
}
