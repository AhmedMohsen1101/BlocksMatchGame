using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matching : MonoBehaviour
{
    private BlockElementDragHandler blockHandler;
    SnapZone snapZone;
    public bool isMatched = false;
    void OnEnable()
    {
        blockHandler = this.gameObject.GetComponent<BlockElementDragHandler>();
    }
   
    private void OnMouseDown()
    {        
        if (!isMatched)
        {
            snapZone = blockHandler.snapZone;
            MatchingManager.currentMatchingColor = blockHandler.currentBlockColor;
            StartMatching(snapZone);

        }
    }
    private void OnMouseDrag()
    {
        if (blockHandler.isDropped)
        {

        }
        
    }
    private void OnMouseUp()
    {
        if (MatchingManager.Matching())
        {
            isMatched = true;
        }
        else
        {
            isMatched = false;
        }
    }
    public void StartMatching(SnapZone snapZone)
    {
        if (blockHandler.isDropped)
        { 
            if(snapZone != null && snapZone.block != null)
            {
                MatchingManager.AddMatchedBlocks(snapZone.block);
            }
            if (snapZone.upSnapZone != null && snapZone.upSnapZone.block != null)
            {
                MatchingManager.AddMatchedBlocks(snapZone.upSnapZone.block);
            }
            if (snapZone.downSnapZone != null && snapZone.downSnapZone.block != null)
            {
                MatchingManager.AddMatchedBlocks(snapZone.downSnapZone.block);
            }
            if (snapZone.rightSnapZone != null && snapZone.rightSnapZone.block != null)
            {
                MatchingManager.AddMatchedBlocks(snapZone.rightSnapZone.block);
            }
            if (snapZone.leftSnapZone != null && snapZone.leftSnapZone.block != null)
            {
                MatchingManager.AddMatchedBlocks(snapZone.leftSnapZone.block);
            }
        }
    }
   

}
