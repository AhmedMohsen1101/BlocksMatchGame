using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matching : MonoBehaviour
{
    private BlockElementDragHandler blockHandler;
    Board board;

    bool isMatched = false;

    private Vector2 currentLocation;
    void Start()
    {
        blockHandler = this.gameObject.GetComponent<BlockElementDragHandler>();
        board = GameObject.FindObjectOfType<Board>();
    }

    private void OnMouseUp()
    {
        if (blockHandler.isDropped)
        {
            GameObject tile = null;
            if (board.Tiles.TryGetValue(blockHandler.snapZone.Location, out tile))
            {
                Debug.Log(tile.name);
            }
            else
            {
                Debug.Log(null);
            }
        }
    }
    
    private void CheckNeighbours()
    {
        //Up

    }
}
