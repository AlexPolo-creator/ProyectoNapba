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

        danoCausado = 0;
        danoCausadoHechicero = 0;
        danoCausadoVerdugo = 0;
        danoCausadoArquero = 0;
        

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void calcularStats()
    {
        poblacionLibre = poblacion - poblacionEnMina - poblacionEnTemplo - poblacionEnCultivo;

        danoCausado = danoCausadoHechicero + danoCausadoVerdugo + danoCausadoArquero;
        danoCausadoHechiceroShow = danoCausadoHechicero;
        danoCausadoVerdugoShow = danoCausadoVerdugo;
        danoCausadoArqueroShow = danoCausadoArquero;

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


        if (danoCausado <= 1000000) //24 hr = 1 day
        {
            danoCausadoMillon = false;
        }
        if (danoCausado >= 1000000) //24 hr = 1 day
        {
            danoCausadoMillon = true;
        }
        if (danoCausadoHechicero <= 1000000) //24 hr = 1 day
        {
            danoCausadoHechiceroMillon = false;
        }
        if (danoCausadoHechicero >= 1000000) //24 hr = 1 day
        {
            danoCausadoHechiceroMillon = true;
        }
        if (danoCausadoVerdugo <= 1000000) //24 hr = 1 day
        {
            danoCausadoVerdugoMillon = false;
        }
        if (danoCausadoVerdugo >= 1000000) //24 hr = 1 day
        {
            danoCausadoVerdugoMillon = true;
        }
        if (danoCausadoArquero <= 1000000) //24 hr = 1 day
        {
            danoCausadoArqueroMillon = false;
        }
        if (danoCausadoArquero >= 1000000) //24 hr = 1 day
        {
            danoCausadoArqueroMillon = true;
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
    public static float danoCritico = 5f;

    [Header("Dano causado:")]
    public int danoCausado = 0;
    public static bool danoCausadoMillon = false;

    public int danoCausadoHechiceroShow = 0;
    public static int danoCausadoHechicero = 0;
    public static bool danoCausadoHechiceroMillon = false;

    public int danoCausadoVerdugoShow = 0;
    public static int danoCausadoVerdugo = 0;
    public static bool danoCausadoVerdugoMillon = false;

    public int danoCausadoArqueroShow = 0;
    public static int danoCausadoArquero = 0;
    public static bool danoCausadoArqueroMillon = false;



    public static int nextSceneToLoad;
    public static void Derrota()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
