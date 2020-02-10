using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingManager : MonoBehaviour
{
    public static BlockColor currentMatchingColor;
    private static List<BlockElementDragHandler> matchedBlocks = new List<BlockElementDragHandler>();
    public static void AddMatchedBlocks(BlockElementDragHandler blockElement)
    {
        if(blockElement != null)
        {
            if (currentMatchingColor == blockElement.currentBlockColor)
            {
                if (!matchedBlocks.Contains(blockElement))
                {
                    matchedBlocks.Add(blockElement);
                    blockElement.GetComponent<Matching>().StartMatching(blockElement.snapZone);
                }
            }
        }
    }
    public static int counter = 0;
    public static bool Matching()
    {
        if(matchedBlocks.Count > 1)
        {
            foreach (BlockElementDragHandler block in matchedBlocks)
            {
                block.snapZone.isEmpty = true;
                Destroy(block.gameObject);
            }
            matchedBlocks.Clear();
            counter = 0;
            return true;
        }
        matchedBlocks.Clear();
        return false;
    }
}
