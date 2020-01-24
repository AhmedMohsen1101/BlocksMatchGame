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
   
}
