using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public Text YellowScoreText;
    public Text RedScoreText;
    public Text GreenScoreText;
    public Text OrangeScoreText;

    public void UpdateRedScore(int value)
    {
        RedScoreText.text = value.ToString();
    }
    public void UpdateOrangeScore(int value)
    {
        OrangeScoreText.text = value.ToString();
    }
    public void UpdateGreeScore(int value)
    {
        GreenScoreText.text = value.ToString();
    }
    public void UpdateYellowScore(int value)
    {
        YellowScoreText.text = value.ToString();
    }
}
