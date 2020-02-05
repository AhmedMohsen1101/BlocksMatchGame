using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matching : MonoBehaviour
{
    private BlockElementDragHandler blockHandler;
    Board board;
    void Start()
    {
        blockHandler = this.gameObject.GetComponent<BlockElementDragHandler>();
        board = GameObject.FindObjectOfType<Board>();
    }

    private void OnMouseUp()
    {
        if (blockHandler.isDropped)
        {
            //Bug
            //Check All neighbour tiles
            GameObject tile = null;
            board.Tiles.TryGetValue(blockHandler.dropLocation, out tile);
            if (!tile)
            {
                Debug.Log("Null");
            }
            else
            {
                Debug.Log(tile.name);
            }
        }
    }

}
