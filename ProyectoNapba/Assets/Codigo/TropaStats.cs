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

    //Druida
    public float druidaRangoInicial = 1.5f;
    public static float druidaRango;

    public float druidaVelocidadDeDisparoInicial = 0.35f; //cuantas veces dispara por segundo
    public static float druidaVelocidadDeDisparo;

    public float druidaAtaqueInicial = 75f;
    public static float druidaAtaque;

    public float druidaMultiplicadorDanoInicial = 75f;
    public static float druidaMultiplicadorDano;

    public float druidaCriticoPorcentajeInicial = 0f;
    public static float druidaCriticoPorcentaje; //entre 100 

    //Inquisidor
    public float inquisidorRangoInicial = 1.5f;
    public static float inquisidorRango;

    public float inquisidorVelocidadDeDisparoInicial = 0.35f; //cuantas veces dispara por segundo
    public static float inquisidorVelocidadDeDisparo;

    public float inquisidorAtaqueInicial = 75f;
    public static float inquisidorAtaque;

    public float inquisidorMultiplicadorDanoInicial = 75f;
    public static float inquisidorMultiplicadorDano;

    public float inquisidorRadioAtaqueInicial = 75f;
    public static float inquisidorRadioAtaque;

    public float inquisidorCriticoPorcentajeInicial = 0f;
    public static float inquisidorCriticoPorcentaje; //entre 100 

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

        druidaVelocidadDeDisparo = druidaVelocidadDeDisparoInicial;
        druidaAtaque = druidaAtaqueInicial;
        druidaRango = druidaRangoInicial;
        druidaMultiplicadorDano = druidaMultiplicadorDanoInicial;
        druidaCriticoPorcentaje = druidaCriticoPorcentajeInicial;

        inquisidorVelocidadDeDisparo = inquisidorVelocidadDeDisparoInicial;
        inquisidorAtaque = inquisidorAtaqueInicial;
        inquisidorRango = inquisidorRangoInicial;
        inquisidorRadioAtaque = inquisidorRadioAtaqueInicial;
        inquisidorMultiplicadorDano = inquisidorMultiplicadorDanoInicial;
        inquisidorCriticoPorcentaje = inquisidorCriticoPorcentajeInicial;


        arqueroVelocidadDeDisparo = arqueroVelocidadDeDisparoInicial;
        arqueroAtaque = arqueroAtaqueInicial;
        arqueroRango = arqueroRangoInicial;
        arqueroCriticoPorcentaje = arqueroCriticoPorcentajeInicial;
    }
}
