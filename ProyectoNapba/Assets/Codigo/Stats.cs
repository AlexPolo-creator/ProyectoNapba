using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public static int numMagos; //estas dos variables sirven para llevar cuenta de cuantas tropas hay colocadas.
    public static int numSoldados;

    public static int numArqueros;
    public static int numLanceros;
    public static int numLanzadoresHacha;

    private void Start()
    {
        InvokeRepeating("calcularStats", 0, 0.1f);

        numMagos = 0;
        numSoldados = 0;

        numArqueros = 0;
        numLanzadoresHacha = 0;
        numLanceros = 0;

        vidaJugador = vidaJugadorInicial;

        oro = oroInicial;
        oroMil = false;

        favorDeDioses = favorDeDiosesInicial;
        favorDeDiosesMil = false;

        poblacionLibre = poblacionLibreInicial;

        poblacionEnCultivo = poblacionEnCultivoInicial;
        poblacionEnMina =    poblacionEnMinaInicial;

        poblacion = poblacionLibre + poblacionEnMina + poblacionEnCultivo;

        comida = comidaInicial;
        comidaMil = false;

        arqueros = 0;
        lanzadoresHacha = 0;
        lanceros = 0;
        hechiceros = 0;
        verdugos = 0;
        druidas = 0;
        inquisidores = 0;

        danoCausado = 0;
        danoCausadoHechicero = 0;
        danoCausadoVerdugo = 0;
        danoCausadoDruida = 0;
        danoCausadoInquisidor = 0;
        danoCausadoArquero = 0;
        danoCausadoLanzadorHacha = 0;
        danoCausadoLancero = 0;


        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void calcularStats()
    {
        if (comida <= 0)
        {
            Derrota(2);
        }
        
        poblacion = poblacionLibre + poblacionEnMina + poblacionEnCultivo;

        danoCausado = danoCausadoHechicero + danoCausadoVerdugo + danoCausadoArquero + danoCausadoDruida + danoCausadoInquisidor + danoCausadoLanzadorHacha + danoCausadoLancero;
        danoCausadoHechiceroShow = danoCausadoHechicero;
        danoCausadoVerdugoShow = danoCausadoVerdugo;
        danoCausadoDruidaShow = danoCausadoDruida;
        danoCausadoInquisidorShow = danoCausadoInquisidor;
        danoCausadoArqueroShow = danoCausadoArquero;
        danoCausadoLanzadorHachaShow = danoCausadoLanzadorHacha;
        danoCausadoLanceroShow = danoCausadoLancero;


        if (favorDeDioses <= 10000) 
        {
            favorDeDiosesMil = false;
        }
        if (favorDeDioses >= 10000) 
        {
            favorDeDiosesMil = true;
        }

        if (oro <= 10000) 
        {
            oroMil = false;
        }
        if (oro >= 10000) 
        {
            oroMil = true;
        }

        if (comida <= 10000)
        {
            comidaMil = false;
        }
        if (comida >= 10000)
        {
            comidaMil = true;
        }

        if (danoCausado <= 1000000)
        {
            danoCausadoMillon = false;
        }
        if (danoCausado >= 1000000)
        {
            danoCausadoMillon = true;
        }
        if (danoCausadoHechicero <= 1000000) 
        {
            danoCausadoHechiceroMillon = false;
        }
        if (danoCausadoHechicero >= 1000000) 
        {
            danoCausadoHechiceroMillon = true;
        }
        if (danoCausadoVerdugo <= 1000000) 
        {
            danoCausadoVerdugoMillon = false;
        }
        if (danoCausadoVerdugo >= 1000000) 
        {
            danoCausadoVerdugoMillon = true;
        }
        if (danoCausadoDruida <= 1000000)
        {
            danoCausadoDruidaMillon = false;
        }
        if (danoCausadoDruida >= 1000000)
        {
            danoCausadoDruidaMillon = true;
        }
        if (danoCausadoInquisidor <= 1000000)
        {
            danoCausadoInquisidorMillon = false;
        }
        if (danoCausadoInquisidor >= 1000000)
        {
            danoCausadoInquisidorMillon = true;
        }
        if (danoCausadoArquero <= 1000000)
        {
            danoCausadoArqueroMillon = false;
        }
        if (danoCausadoArquero >= 1000000) 
        {
            danoCausadoArqueroMillon = true;
        }
        if (danoCausadoLanzadorHacha <= 1000000) 
        {
            danoCausadoLanzadorHachaMillon = false;
        }
        if (danoCausadoLanzadorHacha >= 1000000) 
        {
            danoCausadoLanzadorHachaMillon = true;
        }
        if (danoCausadoLancero >= 1000000) 
        {
            danoCausadoLanceroMillon = true;
        }
        if (danoCausadoLancero <= 1000000) 
        {
            danoCausadoLanceroMillon = false;
        }
    }

    public static int vidaJugador;
    public int vidaJugadorInicial;

    [Header("Recursos:")]

    public static int oro;
    public int oroInicial;
    public static bool oroMil;

    public static int favorDeDioses;
    public int favorDeDiosesInicial;
    public static bool favorDeDiosesMil;

    public static int comida;
    public int comidaInicial;
    public static bool comidaMil;

    public static int poblacionLibre;
    public int poblacionLibreInicial;

    public static int poblacionEnMina;
    public static int poblacionEnCultivo;
    public int poblacionEnMinaInicial;
    public int poblacionEnCultivoInicial;

    public static int poblacion;


    [Header("Tropas para colocar:")]
    public static int arqueros = 0;
    public static int lanzadoresHacha = 0;
    public static int lanceros = 0;

    public static int hechiceros = 0;
    public static int verdugos = 0;
    public static int druidas = 0;
    public static int inquisidores = 0;

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

    public int danoCausadoDruidaShow = 0;
    public static int danoCausadoDruida = 0;
    public static bool danoCausadoDruidaMillon = false;

    public int danoCausadoInquisidorShow = 0;
    public static int danoCausadoInquisidor = 0;
    public static bool danoCausadoInquisidorMillon = false;

    public int danoCausadoArqueroShow = 0;
    public static int danoCausadoArquero = 0;
    public static bool danoCausadoArqueroMillon = false;

    public int danoCausadoLanzadorHachaShow = 0;
    public static int danoCausadoLanzadorHacha = 0;
    public static bool danoCausadoLanzadorHachaMillon = false;

    public int danoCausadoLanceroShow = 0;
    public static int danoCausadoLancero = 0;
    public static bool danoCausadoLanceroMillon = false;


    public static int nextSceneToLoad;
    public static void Derrota(int tipo)
    {
        if (tipo == 1)
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
        if (tipo == 2)
        {
            SceneManager.LoadScene(nextSceneToLoad + 1);
        }
    }

}
