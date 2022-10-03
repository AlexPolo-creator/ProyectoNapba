using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropaStats : MonoBehaviour
{
    //Mago
    public float magoRangoInicial = 1.5f;
    public static float magoRango;

    public float magoVelocidadDeDisparoInicial = 0.35f; //cuantas veces dispara por segundo
    public static float magoVelocidadDeDisparo; 

    public float magoAtaqueInicial = 25f;
    public static float magoAtaque;

    public float magoCriticoPorcentajeInicial = 0f;
    public static float magoCriticoPorcentaje; //entre 100   


    private void Start()
    {
        magoVelocidadDeDisparo = magoVelocidadDeDisparoInicial;
        magoAtaque = magoAtaqueInicial;
        magoRango = magoRangoInicial;
        magoCriticoPorcentaje = magoCriticoPorcentajeInicial;
    }
}
