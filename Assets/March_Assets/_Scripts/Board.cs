using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private float width = 12;
    [SerializeField] private float height = 12;
    public GameObject[] Tile;
    private int counter;


    public void SetupBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject clone = null;
                if (counter % 2 == 0)
                {
                     clone = Instantiate(Tile[0], new Vector3(i * 0.557f, j * 0.557f), Quaternion.identity);
                }
                else if (counter % 2 == 1)
                {
                     clone = Instantiate(Tile[1], new Vector3(i * 0.557f, j * 0.557f), Quaternion.identity);
                }
                clone.transform.parent = this.transform;
                clone.gameObject.name = "(" + i + "," + j + ")";
                counter++;
            }
            counter++;
        }
    }
}
