using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsRama1 : MonoBehaviour
{

    public static Transform[] puntosRama1;

    void Awake()
    {

        puntosRama1 = new Transform[transform.childCount];
        for (int i = 0; i < puntosRama1.Length; i++)
        {
            puntosRama1[i] = transform.GetChild(i);
        }
    }


}
