using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISnappable
{

    void OnSnapping();
    void OnSnapped();
    bool IsThisSnapZoneEmpty();

}
public class SnapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
