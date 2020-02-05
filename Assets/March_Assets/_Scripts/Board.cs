using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private float width = 12;
    [SerializeField] private float height = 12;

    public GameObject[] Tile;
    private int counter;

     public Dictionary<Vector2, GameObject> Tiles = new Dictionary<Vector2, GameObject>();
    //public Dictionary<string, GameObject> Tiles = new Dictionary<string, GameObject>();

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
                    clone = Instantiate(Tile[0], new Vector3(i , j), Quaternion.identity);
                }
                else if (counter % 2 == 1)
                {
                    clone = Instantiate(Tile[1], new Vector3(i, j), Quaternion.identity);
                }
                clone.transform.parent = this.transform;
                clone.gameObject.name = "(" + i + "," + j + ")";
                clone.GetComponent<SnapZone>().SetLocation(i, j);
                 Tiles.Add(new Vector2(i, j), clone);
                counter++;
            }
            counter++;
        }
        Debug.Log(Tiles.Count);
    }
   
    public GameObject GetTile(Vector2 location)
    {
        GameObject tile = null;
        Tiles.TryGetValue(location, out tile);
        return tile;
    }

   
}
