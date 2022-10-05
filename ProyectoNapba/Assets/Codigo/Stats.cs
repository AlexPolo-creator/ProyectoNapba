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

        dañoCausado = 0;
        dañoCausadoHechicero = 0;
        dañoCausadoVerdugo = 0;
        dañoCausadoArquero = 0;
        

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void calcularStats()
    {
        poblacionLibre = poblacion - poblacionEnMina - poblacionEnTemplo - poblacionEnCultivo;

        dañoCausado = dañoCausadoHechicero + dañoCausadoVerdugo + dañoCausadoArquero;
        dañoCausadoHechiceroShow = dañoCausadoHechicero;
        dañoCausadoVerdugoShow = dañoCausadoVerdugo;
        dañoCausadoArqueroShow = dañoCausadoArquero;

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


        if (dañoCausado <= 1000000) //24 hr = 1 day
        {
            dañoCausadoMillon = false;
        }
        if (dañoCausado >= 1000000) //24 hr = 1 day
        {
            dañoCausadoMillon = true;
        }
        if (dañoCausadoHechicero <= 1000000) //24 hr = 1 day
        {
            dañoCausadoHechiceroMillon = false;
        }
        if (dañoCausadoHechicero >= 1000000) //24 hr = 1 day
        {
            dañoCausadoHechiceroMillon = true;
        }
        if (dañoCausadoVerdugo <= 1000000) //24 hr = 1 day
        {
            dañoCausadoVerdugoMillon = false;
        }
        if (dañoCausadoVerdugo >= 1000000) //24 hr = 1 day
        {
            dañoCausadoVerdugoMillon = true;
        }
        if (dañoCausadoArquero <= 1000000) //24 hr = 1 day
        {
            dañoCausadoArqueroMillon = false;
        }
        if (dañoCausadoArquero >= 1000000) //24 hr = 1 day
        {
            dañoCausadoArqueroMillon = true;
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
    public static float dañoCritico = 5f;

    [Header("Daño causado:")]
    public int dañoCausado = 0;
    public static bool dañoCausadoMillon = false;

    public int dañoCausadoHechiceroShow = 0;
    public static int dañoCausadoHechicero = 0;
    public static bool dañoCausadoHechiceroMillon = false;

    public int dañoCausadoVerdugoShow = 0;
    public static int dañoCausadoVerdugo = 0;
    public static bool dañoCausadoVerdugoMillon = false;

    public int dañoCausadoArqueroShow = 0;
    public static int dañoCausadoArquero = 0;
    public static bool dañoCausadoArqueroMillon = false;



    public static int nextSceneToLoad;
    public static void Derrota()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
