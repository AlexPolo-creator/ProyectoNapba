using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private void Start()
    {
        oro = oroInicial;
        favorDeDioses = favorDeDiosesInicial;
        poblacion = poblacionInicial;
        comida = comidaInicial;

        arqueros = 0;
        magos = 0;
    }

    //recursos
    public static int oro;
    public int oroInicial = 250;

    public static int favorDeDioses;
    public int favorDeDiosesInicial = 100;

    public static int poblacion;
    public int poblacionInicial = 50;

    public static int comida;
    public int comidaInicial = 100;

    //tropas listas para colocar
    public static int arqueros = 0;
    public static int magos = 0;


}
