using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public BlockElementDragHandler[] blocks;
    private int counter;
    private void Start()
    {
        blocks = GetComponentsInChildren<BlockElementDragHandler>();
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
        Debug.Log(counter);
        if (counter == blocks.Length)
        {
            Debug.Log(counter);
            return true;
        }
        return false;
    }
}
