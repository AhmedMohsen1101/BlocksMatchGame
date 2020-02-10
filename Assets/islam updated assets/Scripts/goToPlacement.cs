using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToPlacement : MonoBehaviour
{
    private Rigidbody2D RB;
    public Transform placement;
    // a bool to decide if the block is placed in the board
    public bool isPlaced;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();

    }
    private void OnMouseDown()
    {
        if (isPlaced)
        {
            RB.transform.position = placement.position;
        }
    }
}
