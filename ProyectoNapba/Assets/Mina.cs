using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour
{

    public float velocidadMineros = 5f;
    public int produccionOro = 5;


    void Start()
    {
        InvokeRepeating("SumarOro", 1, velocidadMineros);
    }

   void SumarOro()
    {
        Stats.oro += produccionOro * Stats.poblacionEnMina;
    }

}
