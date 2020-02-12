using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int yellowScore = 0;
    public int redScore = 0;
    public int greenScore = 0;
    public int orangeScore = 0;
    private HUD hud;
    private void OnEnable()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BlockElementDragHandler>().currentBlockColor == BlockColor.Red)
        {
            redScore++;
            hud.UpdateRedScore(redScore);
        }
        else if (col.GetComponent<BlockElementDragHandler>().currentBlockColor == BlockColor.Green)
        {
            greenScore++;
            hud.UpdateGreeScore(greenScore);
        }
        else if (col.GetComponent<BlockElementDragHandler>().currentBlockColor == BlockColor.Yellow)
        {
            yellowScore++;
            hud.UpdateYellowScore(yellowScore);
        }
        else if (col.GetComponent<BlockElementDragHandler>().currentBlockColor == BlockColor.Orange)
        {
            orangeScore++;
            hud.UpdateOrangeScore(orangeScore);
        }
        col.gameObject.SetActive(false);
        Destroy(col.gameObject,3);
    } 
}
