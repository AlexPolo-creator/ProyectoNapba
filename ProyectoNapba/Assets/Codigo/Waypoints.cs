using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    
    public static Transform[] puntosRama1;
    public static int rama1length = 0;
    public static int rama2length = 0; 
    public static Transform[] puntosRama2;
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
            ultimo = puntosRama1[rama1length-1];
        }
        else if (rama == 2)
        {
            puntosRama2 = new Transform[transform.childCount];
            for (int i = 0; i < puntosRama2.Length; i++)
            {
                puntosRama2[i] = transform.GetChild(i);
                rama2length++;
            }
            ultimo = puntosRama2[rama2length-1];
        }




    }
  
}
