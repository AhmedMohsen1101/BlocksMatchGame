using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private float width = 12;
    [SerializeField] private float height = 12;

    public GameObject[] Tile;
    private int counter;

    [HideInInspector] public List<GameObject> Tiles = new List<GameObject>();

    public void SetupBoard()
    {
        if (Tiles.Count > 0)
        {
            ClearTiles();
        }
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

                if (!Tiles.Contains(clone))
                {
                    Tiles.Add(clone);
                }
                counter++;
            }
            counter++;
        }
    }

    public void ClearTiles()
    {
        for (int i = 0; i < Tiles.Count; i++)
        {
            Destroy(Tiles[i]);
            Tiles.RemoveAt(i);
        }
    }
}
