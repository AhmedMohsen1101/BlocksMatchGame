using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MatchingManager : MonoBehaviour
{
    public static BlockColor currentMatchingColor;
    public Transform Green;
    public Transform Yellow;
    public Transform Red;
    public Transform Orange;
    public float TweenTime = 0.5f;
    private static float tweenTime;
    private static Transform green, yellow, red, orange;

    private void Start()
    {
        green = Green;
        yellow = Yellow;
        red = Red;
        orange = Orange;
        tweenTime = TweenTime;
    }
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
    public static bool Matching()
    {
        if(matchedBlocks.Count > 1)
        {
            foreach (BlockElementDragHandler block in matchedBlocks)
            {
                tweenTime += 0.2f;
                block.snapZone.isEmpty = true;
                if(currentMatchingColor == BlockColor.Green)
                {
                    block.transform.DOMove(green.position, tweenTime, false);
                }
                else if (currentMatchingColor == BlockColor.Red)
                {
                    block.transform.DOMove(red.position, tweenTime, false);
                }
                else if (currentMatchingColor == BlockColor.Yellow)
                {
                    block.transform.DOMove(yellow.position, tweenTime, false);
                }
                else if (currentMatchingColor == BlockColor.Orange)
                {
                    block.transform.DOMove(orange.position, tweenTime,false);
                }
            }
            matchedBlocks.Clear();
            tweenTime = 0.5f;
            return true;
        }
        matchedBlocks.Clear();
        tweenTime = 0.5f;
        return false;
    }
}
