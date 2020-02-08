using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockElementDragHandler : MonoBehaviour, ISnappable
{
    #region Drag Controls Entity

    [HideInInspector] public bool isTheTileEmpty;

    public Transform raycastPosition;
    private Vector3 mOffset;
    private float mZCoord;
    [HideInInspector] public bool isDragged;
    public bool isDropped = false;

    #endregion

    #region Parenting Logical Solution Entity

    private Transform theParent;

    #endregion

    private SpriteRenderer spriteRenderer;
    private BlockManager blockManager;
    public SnapZone snapZone;
    RaycastHit2D hit;
    LayerMask tileLayerMask;
    public Color currentBlockColor;
    public Vector2 dropLocation;
    private void OnEnable()
    {
        theParent = transform.parent;
        tileLayerMask = LayerMask.GetMask("Tile");
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        blockManager = this.gameObject.GetComponentInParent<BlockManager>();
        currentBlockColor = this.gameObject.GetComponent<RandomColor>().GetColor();
        spriteRenderer.sortingOrder = 2;
    }

    private void FixedUpdate()
    {
        if (!isDropped)
        {
            //OnSnapping();
        }
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
        if (isDropped)
        {
            return;
        }
        mZCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        mOffset = transform.position - GetMousePos();

        #region Parenting Logical Solution Entity

        transform.parent = null;
        theParent.parent = transform;

        #endregion
        isDragged = true;
        OnSnappingBegin();
    }
    public virtual void OnMouseDrag()
    {
        if (isDropped)
        {
            return;
        }
        #region Drag Controls Entity

        transform.position = GetMousePos() + mOffset;

        #endregion
    }

    public virtual void OnMouseUp()
    {
        if (isDropped)
        {
            return;
        }
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
        for (int i = 0; i < blockManager.blocks.Length; i++)
        {
            blockManager.blocks[i].OnSnapping();
        }
        OnSnapped();
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
        spriteRenderer.sortingOrder = 5;
        ScaleUpDown(0.7f);
    }

    public void OnSnapping()
    {
        CheckWithRaycast();
    }

    public void OnSnapped()
    {
        ScaleUpDown(1f);
        spriteRenderer.sortingOrder = 2;

        //Check if that all tiles are touched from all blocks are empty
        if (blockManager.AllEmpty())
        {
            Drop();
        }
        else
        {
            //return it to the it Space
            blockManager.unSnapped = true;
            
        }
    }

    #endregion
    private void Drop()
    {
        this.transform.position = hit.collider.transform.position;
        foreach (BlockElementDragHandler block in blockManager.blocks)
        {
            block.CheckWithRaycast();
            block.isDropped = true;
            block.dropLocation = block.snapZone.GetLocation();
            block.snapZone.SetAttachedBlock(block);
            block.snapZone.isEmpty = false;
            //block.transform.parent = block.snapZone.gameObject.transform;
            
        }
        //To Generate new shape
        //Destroy(blockManager.gameObject);
        EventManager.TriggerEvent("Generate", blockManager.startPosition);
    }
    public void CheckWithRaycast()
    {
        hit = Physics2D.Raycast(raycastPosition.position, raycastPosition.forward, 1f, tileLayerMask);
        
        if (hit.collider != null)
        {
            snapZone = hit.collider.GetComponent<SnapZone>();
            //if (snapZone != null)
            //{

            //}
            isTheTileEmpty = snapZone.isEmpty;

        }
        else
        {
            isTheTileEmpty = false;
        }
    }
    private void ScaleUpDown(float value)
    {
        this.gameObject.transform.root.localScale = new Vector2(value, value);
    }
}
