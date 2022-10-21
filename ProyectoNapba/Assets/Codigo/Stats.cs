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

        comidaLibre = comidaLibreInicial;
        

        comidaEnCultivo = comidaEnCultivoInicial;
        comidaEnMina =    comidaEnMinaInicial;
        comidaEnTemplo =  comidaEnTemploInicial;

        comida= comidaLibre + comidaEnMina + comidaEnTemplo + comidaEnCultivo;

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

        comidaLibre = comida - comidaEnMina - comidaEnTemplo - comidaEnCultivo;

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
    public int vidaJugadorInicial = 100;

    [Header("Recursos:")]

    public static int oro;
    public int oroInicial = 250;
    public static bool oroMil = false;

    public static int favorDeDioses;
    public int favorDeDiosesInicial = 100;
    public static bool favorDeDiosesMil = false;

    public static int comidaLibre;
    public int comidaLibreInicial = 50;

    public static int comidaEnMina;
    public static int comidaEnTemplo;
    public static int comidaEnCultivo;
    public int comidaEnMinaInicial;
    public int comidaEnTemploInicial;
    public int comidaEnCultivoInicial;

    public static int comida;


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
    public static void Derrota()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
