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

    //Arquero
    public float arqueroRangoInicial = 1.5f;
    public static float arqueroRango;

    public float arqueroVelocidadDeDisparoInicial = 0.35f; //cuantas veces dispara por segundo
    public static float arqueroVelocidadDeDisparo;

    public float arqueroAtaqueInicial = 25f;
    public static float arqueroAtaque;

    public float arqueroCriticoPorcentajeInicial = 0f;
    public static float arqueroCriticoPorcentaje; //entre 100   

    private void Start()
    {
        magoVelocidadDeDisparo = magoVelocidadDeDisparoInicial;
        magoAtaque = magoAtaqueInicial;
        magoRango = magoRangoInicial;
        magoCriticoPorcentaje = magoCriticoPorcentajeInicial;

        arqueroVelocidadDeDisparo = arqueroVelocidadDeDisparoInicial;
        arqueroAtaque = arqueroAtaqueInicial;
        arqueroRango = arqueroRangoInicial;
        arqueroCriticoPorcentaje = arqueroCriticoPorcentajeInicial;
    }
}
