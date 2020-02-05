using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlockManager : MonoBehaviour
{
    [HideInInspector] public BlockElementDragHandler[] blocks;
    [HideInInspector] public Vector3 startPosition, finalPoint;
    [HideInInspector] public bool unSnapped = false;
    private int counter;
    private void Start()
    {
        blocks = GetComponentsInChildren<BlockElementDragHandler>();
        startPosition = this.transform.position;
    }
    public bool AllEmpty()
    {
        counter = 0;
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].isTheTileEmpty)
            {
                counter++;
            }
        }
        if (counter == blocks.Length)
        {
            return true;
        }
        return false;
    }
    private void Update()
    {
        if (unSnapped)
            ResetPosition();

        if (unSnapped && this.transform.position == startPosition)
        {
            unSnapped = false;
        }
    }
    private void ResetPosition()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, startPosition, 1f);
    }
    
}
