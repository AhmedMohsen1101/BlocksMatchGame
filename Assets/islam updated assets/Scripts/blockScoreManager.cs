using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text blocksscored;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tile")
        {
            score++;
            blocksscored.text = "" + score;
        }
    }
}
