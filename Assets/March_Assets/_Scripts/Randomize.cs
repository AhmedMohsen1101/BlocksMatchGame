using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IRandomize
{
    void RandomLocation();
    void RandamShape(Vector3 position);
    void RandomColor();
}

public class Randomize : MonoBehaviour, IRandomize
{

    float rotationAngle = 90;

    public virtual void RandamShape(Vector3 position)
    {

    }

    public virtual void RandomColor()
    {
        
    }

    public virtual void RandomLocation()
    {
        
    }

    public virtual Quaternion RandomRotation()
    {
        int randomRotation = Random.Range(0, 4);

        Quaternion rotation = Quaternion.Euler(0, 0, rotationAngle * randomRotation);
        return rotation;
    }
}
