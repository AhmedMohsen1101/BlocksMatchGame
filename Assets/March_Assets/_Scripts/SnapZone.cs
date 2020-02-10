using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapZone : MonoBehaviour
{
    public bool isEmpty = true;
    public BlockElementDragHandler block;
    public Vector2 Location;
    private RaycastHit2D[] up, down, left, right;
    public SnapZone upSnapZone, downSnapZone, leftSnapZone, rightSnapZone;
    int frameCounter;
    
    private void FixedUpdate()
    {
        if (frameCounter <= 10)
        {
            frameCounter++;
            GetNeighbours();
        }
        
    }
    private void GetNeighbours()
    {
        up = Physics2D.RaycastAll(this.transform.position, transform.up, 0.6f);
        down = Physics2D.RaycastAll(this.transform.position, -transform.up, 0.6f);
        right = Physics2D.RaycastAll(this.transform.position, transform.right, 0.6f);
        left = Physics2D.RaycastAll(this.transform.position, -transform.right, 0.6f);

        
        upSnapZone = CheckRaycastHitArray(up);
        downSnapZone = CheckRaycastHitArray(down);
        rightSnapZone = CheckRaycastHitArray(right);
        leftSnapZone = CheckRaycastHitArray(left);
    }
    private SnapZone CheckRaycastHitArray(RaycastHit2D[] arr)
    {
        SnapZone snapZone = null;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].collider.gameObject != this.gameObject)
            {
                if (snapZone == null)
                {
                    snapZone = arr[i].collider.GetComponent<SnapZone>();
                    return snapZone;
                }
            }
        }
        return null;
    }

    public void SetLocation(int width, int height)
    {
        Location = new Vector2(width, height);
    }
    public Vector2 GetLocation()
    {
        return Location;
    }
    public void SetAttachedBlock(BlockElementDragHandler b)
    {
        block = b;
    }
}
