using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Randomize
{
    public GameObject[] boxPrefabs;
    public Transform[] boxSpawnPosition = new Transform[3];

    //Generate shapes in the bar to be ready to drag and drop
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 position = boxSpawnPosition[i].position;
            RandamShape(position);
        }
    }
    
    public override void RandamShape(Vector3 position)
    {
        GenerateNewShape(position, RandomRotation());
    }

    //Generate New Shape
    private void GenerateNewShape(Vector3 position, Quaternion rotation)
    {
        int random = Random.Range(0, boxPrefabs.Length);
        Instantiate(boxPrefabs[random], position, rotation);
    }
}
