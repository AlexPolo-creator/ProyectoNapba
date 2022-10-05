using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public static int numMagos; //estas dos variables sirven para llevar cuenta de cuantas tropas hay colocadas.
    public static int numSoldados;


    private void Start()
    {
        InvokeRepeating("calcularStats", 0, 0.1f);

        numMagos = 0;
        numSoldados = 0;

        vidaJugador = vidaJugadorInicial;

        oro = oroInicial;
        oroMil = false;

        favorDeDioses = favorDeDiosesInicial;
        favorDeDiosesMil = false;

        poblacionLibre = poblacionLibreInicial;
        

        poblacionEnCultivo = poblacionEnCultivoInicial;
        poblacionEnMina = poblacionEnMinaInicial;
        poblacionEnTemplo = poblacionEnTemploInicial;

        poblacion = poblacionLibre + poblacionEnMina + poblacionEnTemplo + poblacionEnCultivo;

        arqueros = 0;
        hechiceros = 0;
        verdugos = 0;

        da�oCausado = 0;
        da�oCausadoHechicero = 0;
        da�oCausadoVerdugo = 0;
        da�oCausadoArquero = 0;
        

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void calcularStats()
    {
        poblacionLibre = poblacion - poblacionEnMina - poblacionEnTemplo - poblacionEnCultivo;

        da�oCausado = da�oCausadoHechicero + da�oCausadoVerdugo + da�oCausadoArquero;
        da�oCausadoHechiceroShow = da�oCausadoHechicero;
        da�oCausadoVerdugoShow = da�oCausadoVerdugo;
        da�oCausadoArqueroShow = da�oCausadoArquero;

        if (favorDeDioses <= 10000) // 60 sec = 1 min
        {
            favorDeDiosesMil = false;
        }
        if (favorDeDioses >= 10000) // 60 sec = 1 min
        {
            favorDeDiosesMil = true;
        }

        if (oro <= 10000) //60 min = 1 hr
        {
            oroMil = false;
        }
        if (oro >= 10000) //60 min = 1 hr
        {
            oroMil = true;
        }


        if (da�oCausado <= 1000000) //24 hr = 1 day
        {
            da�oCausadoMillon = false;
        }
        if (da�oCausado >= 1000000) //24 hr = 1 day
        {
            da�oCausadoMillon = true;
        }
        if (da�oCausadoHechicero <= 1000000) //24 hr = 1 day
        {
            da�oCausadoHechiceroMillon = false;
        }
        if (da�oCausadoHechicero >= 1000000) //24 hr = 1 day
        {
            da�oCausadoHechiceroMillon = true;
        }
        if (da�oCausadoVerdugo <= 1000000) //24 hr = 1 day
        {
            da�oCausadoVerdugoMillon = false;
        }
        if (da�oCausadoVerdugo >= 1000000) //24 hr = 1 day
        {
            da�oCausadoVerdugoMillon = true;
        }
        if (da�oCausadoArquero <= 1000000) //24 hr = 1 day
        {
            da�oCausadoArqueroMillon = false;
        }
        if (da�oCausadoArquero >= 1000000) //24 hr = 1 day
        {
            da�oCausadoArqueroMillon = true;
        }


    }

    public static int vidaJugador;
    public int vidaJugadorInicial = 100;

    [Header("Recursos:")]

    public static int oro;
    public int oroInicial = 250;
    public static bool oroMil = false;

    public static int favorDeDioses;
    public int favorDeDiosesInicial = 100;
    public static bool favorDeDiosesMil = false;

    public static int poblacionLibre;
    public int poblacionLibreInicial = 50;

    public static int poblacionEnMina;
    public static int poblacionEnTemplo;
    public static int poblacionEnCultivo;
    public int poblacionEnMinaInicial;
    public int poblacionEnTemploInicial;
    public int poblacionEnCultivoInicial;

    public static int poblacion;


    [Header("Tropas para colocar:")]
    public static int arqueros = 0;
    public static int hechiceros = 0;
    public static int verdugos = 0;

    [Header("Otras Stats:")]
    public static float da�oCritico = 5f;

    [Header("Da�o causado:")]
    public int da�oCausado = 0;
    public static bool da�oCausadoMillon = false;

    public int da�oCausadoHechiceroShow = 0;
    public static int da�oCausadoHechicero = 0;
    public static bool da�oCausadoHechiceroMillon = false;

    public int da�oCausadoVerdugoShow = 0;
    public static int da�oCausadoVerdugo = 0;
    public static bool da�oCausadoVerdugoMillon = false;

    public int da�oCausadoArqueroShow = 0;
    public static int da�oCausadoArquero = 0;
    public static bool da�oCausadoArqueroMillon = false;



    public static int nextSceneToLoad;
    public static void Derrota()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
