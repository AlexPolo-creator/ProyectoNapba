using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsRama2 : MonoBehaviour
{

    public static Transform[] puntosRama2;

    void Awake()
    {

        puntosRama2 = new Transform[transform.childCount];
        for (int i = 0; i < puntosRama2.Length; i++)
        {
            puntosRama2[i] = transform.GetChild(i);
        }
    }


}
