using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int width = 12;
    [SerializeField] private int height = 12;

    public GameObject[] Tile;
    private int counter;

    public Dictionary<Vector2, GameObject> Tiles = new Dictionary<Vector2, GameObject>();
    private void Awake()
    {
        SetupBoard();
    }
    public void SetupBoard()
    {
        Tiles.Clear();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject clone = null;
                if (counter % 2 == 0)
                {
                    clone = Instantiate(Tile[0], new Vector3(i, j), Quaternion.identity) as GameObject;

                }
                else if (counter % 2 == 1)
                {
                    clone = Instantiate(Tile[1], new Vector3(i, j), Quaternion.identity) as GameObject;

                }
                clone.transform.parent = this.transform;
                clone.gameObject.name = "(" + i + "," + j + ")";
                clone.GetComponent<SnapZone>().SetLocation(i, j);
               
                Tiles.Add(new Vector2(i,j), clone);
                counter++;
            }
            counter++;
        }
        Debug.Log(Tiles.Count);
    }
    GameObject tile = null;

 
}
