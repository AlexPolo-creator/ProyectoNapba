using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    
    public static Transform[] puntosRama1;
    public static Transform[] puntosRama2;
    public int rama;

    void Awake()
    {
        if (rama == 1)
        {
            puntosRama1 = new Transform[transform.childCount];
            for (int i = 0; i < puntosRama1.Length; i++)
            {
                puntosRama1[i] = transform.GetChild(i);
            }
        }
        else if (rama == 2)
        {
            puntosRama2 = new Transform[transform.childCount];
            for (int i = 0; i < puntosRama2.Length; i++)
            {
                puntosRama2[i] = transform.GetChild(i);
            }
        }




    }
  
}
