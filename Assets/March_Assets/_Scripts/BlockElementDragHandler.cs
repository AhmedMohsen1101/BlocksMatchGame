﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockElementDragHandler : MonoBehaviour, ISnappable
{
    #region Drag Controls Entity
    
    private Vector3 mOffset;
    private float mZCoord;
    [HideInInspector] public bool isDragged; 
    
    #endregion

    #region Parenting Logical Solution Entity
    
    private Transform theParent;

    #endregion

    public bool isTheTileEmpty;
    RaycastHit2D hit;
    LayerMask tileLayerMask;


    private void Start()
    {
        tileLayerMask = LayerMask.GetMask("Tile");
    }



    /// <summary>
    /// Our solution is very simple in order to understand how we gonna solve the snappig problem will start off of
    /// the dragging and then will talk about the snapping.
    /// first of all we need to consider the block as a Car which can have only one driver at a time, in which the driver
    /// will drive the whole veichle "The Car", and then it is gonna be the temporary parent of the whole family.
    /// so basically it is gonna be the parent of its original parent "TheParent" of the family.
    /// We would like to consider the snapping operation as a landing operation.
    /// Imagine the landing operation as if it was airplane landing operation, somebody has to manage the whole process.
    /// So the process is to land each part of the plane on the ground by only one script which is the currently dragged object.
    /// Or the driver of the car the parent of "The Parent"
    /// </summary>
    public virtual void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMousePos();
       
        #region Parenting Logical Solution Entity
        
        theParent = transform.parent;
        transform.parent = null;

        //TODO: fix this
        theParent.parent = transform;

        #endregion
    }
    public virtual void OnMouseDrag()
    {
        #region Drag Controls Entity

        transform.position = GetMousePos() + mOffset;

        #endregion

        OnSnapping();
    }

    public virtual void OnMouseUp()
    {

        #region Drag Controls Entity

        // Check the object if it on the right postion or not if make the snapzone code
        isDragged = false;

        #endregion

        #region Parenting Logical Solution Entity
        //Instead of reversing the block parenting order at this point, 
        //will check whether the each of the block's elements are going to land on empty snapZone
        //if all the blocks are ok and their opposite snapZones are empty so then will consider the 
        //dragged element as manager of the landing operation, and it will put himself in place first,
        //as he has became the temporary parent of his original parent.

        theParent.parent = null;
        transform.parent = theParent;

        #endregion
    }

    #region Drag Controls Entity

    private Vector3 GetMousePos()
    {
        // Pixel Coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // Z Coordinate of game object on screen
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void OnSnappingBegin()
    {
        throw new System.NotImplementedException();
    }

    public void OnSnapping()
    {
        CheckWithRaycast();
    }

    private void CheckWithRaycast()
    {
        hit = Physics2D.Raycast(this.transform.position, -this.transform.forward, 5f, tileLayerMask);
        if (hit)
        {
            Debug.Log(this.gameObject.name);
            isTheTileEmpty = true;
        }
        else
        {
            isTheTileEmpty = false;
        }
    }

    public void OnSnapped()
    {
        throw new System.NotImplementedException();
    }

    #endregion

}