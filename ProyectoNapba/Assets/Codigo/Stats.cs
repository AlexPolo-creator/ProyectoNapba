using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    private void Start()
    {
        vidaJugador = vidaJugadorInicial;

        oro = oroInicial;
        favorDeDioses = favorDeDiosesInicial;
        poblacion = poblacionInicial;
        comida = comidaInicial;

        arqueros = 0;
        magos = 0;

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }


    public static int vidaJugador;
    public int vidaJugadorInicial = 100;

    [Header("Recursos:")]

    public static int oro;
    public int oroInicial = 250;

    public static int favorDeDioses;
    public int favorDeDiosesInicial = 100;

    public static int poblacion;
    public int poblacionInicial = 50;

    public static int comida;
    public int comidaInicial = 100;

    [Header("Tropas para colocar:")]

    public static int arqueros = 0;
    public static int magos = 0;


    public static int nextSceneToLoad;
    public static void Derrota()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

}
