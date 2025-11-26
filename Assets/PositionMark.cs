using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMark : MonoBehaviour
{
    void Awake()
    {
        Renderer rdr = GetComponent<Renderer>();
        if ( rdr != null )
        {
            rdr.enabled = false;
        }
    }

}
