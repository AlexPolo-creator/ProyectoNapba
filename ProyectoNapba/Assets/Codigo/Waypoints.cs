using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{    
    public static Transform[] puntosRama1;
    public static Transform[] puntosRama2;
    public static Transform[] puntosRama3;
    public static Transform[] puntosRama4;
    public static Transform[] puntosRama5;

    public static int rama1length = 0;
    public static int rama2length = 0;
    public static int rama3length = 0;
    public static int rama4length = 0;
    public static int rama5length = 0;

    public static Transform ultimo ;
    public int rama ;

    void Awake()
    {
        if (rama == 1)
        {
            puntosRama1 = new Transform[transform.childCount];
            for (int i = 0; i < puntosRama1.Length; i++)
            {
                puntosRama1[i] = transform.GetChild(i);
                rama1length++;
            }
            ultimo = puntosRama1[rama1length - 1];
        }
        else if (rama == 2)
        {
            puntosRama2 = new Transform[transform.childCount];
            for (int i = 0; i < puntosRama2.Length; i++)
            {
                puntosRama2[i] = transform.GetChild(i);
                rama2length++;
            }
            ultimo = puntosRama2[rama2length - 1];
        }
        else if (rama == 3)
        {
            puntosRama3 = new Transform[transform.childCount];
            for (int i = 0; i < puntosRama3.Length; i++)
            {
                puntosRama3[i] = transform.GetChild(i);
                rama3length++;
            }
            ultimo = puntosRama3[rama3length - 1];
        }
        else if (rama == 4)
        {
            puntosRama4 = new Transform[transform.childCount];
            for (int i = 0; i < puntosRama4.Length; i++)
            {
                puntosRama4[i] = transform.GetChild(i);
                rama4length++;
            }
            ultimo = puntosRama4[rama4length-1];
        }
        else if (rama == 5)
        {
            puntosRama5 = new Transform[transform.childCount];
            for (int i = 0; i < puntosRama5.Length; i++)
            {
                puntosRama5[i] = transform.GetChild(i);
                rama5length++;
            }
            ultimo = puntosRama5[rama5length-1];
        }

    }
  
}
