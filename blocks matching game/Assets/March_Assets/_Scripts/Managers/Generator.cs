using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IRandomize
{
    void RandomLocation();
    void RandamShape(Vector3 position);
    void RandomColor();
}
public class Generator : MonoBehaviour, IRandomize
{
    public GameObject[] boxPrefabs;
    float rotationAngle = 90;
    public Transform[] boxSpawnPosition = new Transform[3];
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 position = boxSpawnPosition[i].position;
            RandamShape(position);
        }
    }

    private void Update()
    {
        
    }
    public void RandamShape(Vector3 position)
    {
        int random = Random.Range(0, boxPrefabs.Length);

        int randomRotation = Random.Range(0, 4);

        Quaternion rotation = Quaternion.Euler(0, 0, rotationAngle * randomRotation);
        Instantiate(boxPrefabs[random], position, rotation);
    }

    public void RandomColor()
    {
        throw new System.NotImplementedException();
    }

    public void RandomLocation()
    {
        throw new System.NotImplementedException();
    }
}
