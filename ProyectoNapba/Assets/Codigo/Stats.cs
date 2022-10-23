using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Stats : MonoBehaviour
{
    public static int numMagos; //estas dos variables sirven para llevar cuenta de cuantas tropas hay colocadas.
    public static int numSoldados;

    public static int numArqueros;
    public static int numLanceros;
    public static int numLanzadoresHacha;

    public static int cadaCuantosAtaquesLanzarHielo;
    public static bool puedeLanzarHielo;
    public static bool puedeLanzarHielo2;

    private void Start()
    {
        deserualizar();
        OrdenarPuntuaciones();
        InvokeRepeating("calcularStats", 0, 0.1f);

        printPuntuaciones();

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

        cadaCuantosAtaquesLanzarHielo = 4;
        puedeLanzarHielo = false;
        puedeLanzarHielo = false;

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void calcularStats()
    {
        if (comida <= 0)
        {
            Derrota(2);
        }
        if (vidaJugador <= 0)
        {
            Derrota(1);
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
    void Derrota(int tipo)
    {
        if (tipo == 1)
        {
            dias = CicloDiaNoche.dias;
            anadirPuntuaciones();
            serializar();
            SceneManager.LoadScene(nextSceneToLoad + 1);
        }
        if (tipo == 2)
        {
            dias = CicloDiaNoche.dias;
            anadirPuntuaciones();
            serializar();

            SceneManager.LoadScene(nextSceneToLoad + 2);
        }
    }


    //tabla de puntuaciones:
    //variables escena gameplay:
    [SerializeField] int[] tabla = { 0, 0, 0, 0, 0 };
    public static int dias, aux;     //SOLO PRUEBAS TEMPORALES

    //variables escena menuInicio:
    public TextMeshProUGUI[] top5;

    void OrdenarPuntuaciones()
    {
        for (int i = 0; i<5; i++)
        {
            for (int j = 0; j<4; j++)
            {
                if (tabla[j] < tabla[j+1])
                {
                    aux = tabla[j];
                    tabla[j] = tabla[j+1];
                    tabla[j+1] = aux;
                }
            }
        }
    }
    void anadirPuntuaciones()
    {
        OrdenarPuntuaciones();
        if (tabla[4] <= dias)
        {
            tabla[4] = dias;
            for (int i = 0; i <5; i++)
            {
                Debug.Log(tabla[i]);
            }
            serializar();
            // aqui irian los dias aguantados en la partida actual suplantando la 
            //cuando muere se guarda y se reordena con la nueva puntuacion            
        }

        OrdenarPuntuaciones();
    }
    public void printPuntuaciones()
    {

        for (int i = 0; i<5; i++)
        {
            top5[i].text = tabla[i].ToString();
        }
    }
    void serializar()
    {
        PlayerPrefs.SetInt("top1", tabla[0]);
        PlayerPrefs.SetInt("top2", tabla[1]);
        PlayerPrefs.SetInt("top3", tabla[2]);
        PlayerPrefs.SetInt("top4", tabla[3]);
        PlayerPrefs.SetInt("top5", tabla[4]);

    }
    void deserualizar()
    {
        tabla[0] = PlayerPrefs.GetInt("top1");
        tabla[1] = PlayerPrefs.GetInt("top2");
        tabla[2] = PlayerPrefs.GetInt("top3");
        tabla[3] = PlayerPrefs.GetInt("top4");
        tabla[4] = PlayerPrefs.GetInt("top5");
    }
    public void Reset()
    {
        tabla[0] = 0;
        tabla[1] = 0;
        tabla[2] = 0;
        tabla[3] = 0;
        tabla[4] = 0;
        serializar();
        printPuntuaciones();
    }


}
