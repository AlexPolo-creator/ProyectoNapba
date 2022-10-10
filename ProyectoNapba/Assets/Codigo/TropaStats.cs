using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropaStats : MonoBehaviour
{
    [Header("Magos:")]

    //Hechidero
    public float hechiceroRangoInicial = 1.5f;
    public static float hechiceroRango;

    public float hechiceroVelocidadDeDisparoInicial = 0.35f; //cuantas veces dispara por segundo
    public static float hechiceroVelocidadDeDisparo; 

    public float hechiceroAtaqueInicial = 75f;
    public static float hechiceroAtaque;

    public float hechiceroCriticoPorcentajeInicial = 0f;
    public static float hechiceroCriticoPorcentaje; //entre 100 



    //Verdugo
    public float verdugoRangoInicial = 1.5f;
    public static float verdugoRango;

    public float verdugoPuntoEjecucionInicial;
    public static float verdugoPuntoEjecucion;

    public float verdugoVelocidadDeDisparoInicial = 0.35f; //cuantas veces dispara por segundo
    public static float verdugoVelocidadDeDisparo;

    public float verdugoAtaqueInicial = 30f;
    public static float verdugoAtaque;

    public float verdugoCriticoPorcentajeInicial = 0f;
    public static float verdugoCriticoPorcentaje; //entre 100 

    [Header("Soldados:")]

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

        hechiceroVelocidadDeDisparo = hechiceroVelocidadDeDisparoInicial;
        hechiceroAtaque = hechiceroAtaqueInicial;
        hechiceroRango = hechiceroRangoInicial;
        hechiceroCriticoPorcentaje = hechiceroCriticoPorcentajeInicial;

        verdugoVelocidadDeDisparo = verdugoVelocidadDeDisparoInicial;
        verdugoAtaque = verdugoAtaqueInicial;
        verdugoRango = verdugoRangoInicial;
        verdugoPuntoEjecucion = verdugoPuntoEjecucionInicial;
        verdugoCriticoPorcentaje = verdugoCriticoPorcentajeInicial;


        arqueroVelocidadDeDisparo = arqueroVelocidadDeDisparoInicial;
        arqueroAtaque = arqueroAtaqueInicial;
        arqueroRango = arqueroRangoInicial;
        arqueroCriticoPorcentaje = arqueroCriticoPorcentajeInicial;
    }
}
