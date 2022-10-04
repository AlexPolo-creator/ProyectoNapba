using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templo : MonoBehaviour
{
    //Mejoras globales (Bendiciones):
    public static bool mejoraBotinDivino1;
    public bool botonBotinActivado = false;
    public static int numBotinDivino1;
    public int precioBotinDivino1 = 75;
    public GameObject botonBotinDivino1;

    public void ActivarBotinDivino1()
    {
        if (Stats.favorDeDioses >= precioBotinDivino1)
        {
            botonBotinDivino1.SetActive(false);
            botonBotinActivado = false;
            numBotonesMejoraAxctivos--;
            numBotinDivino1++;
            mejoraBotinDivino1 = true;
            Stats.favorDeDioses -= precioBotinDivino1;              
        }
    }

    public static bool mejoraVivacidad1;
    public bool botonVivacidadActivado = false;
    public static int numVivacidad1;
    public int precioVivacidad1 = 50;
    public GameObject botonVivacidad1;
    public void ActivarVivacidad1()
    {
        if (Stats.favorDeDioses >= precioVivacidad1)
        {
            botonVivacidad1.SetActive(false);
            botonVivacidadActivado = false;
            numBotonesMejoraAxctivos--;
            numVivacidad1++;
            mejoraVivacidad1 = true;
            TropaStats.magoVelocidadDeDisparo = TropaStats.magoVelocidadDeDisparo * (1 + (0.15f * numVivacidad1)); // + porque la velocidad de ataque de los magos es ataques/segundo y no al reves
            Stats.favorDeDioses -= precioVivacidad1;           
        }      
    }

    public static bool mejoraCastigoPiadoso1;
    public bool botonCastigoActivado = false;
    public static int numCastigoPiadoso1;
    public int precioCastigoPiadoso1 = 30;
    public GameObject botonCastigoPiadoso1;
 
    public void ActivarCastigoPiadoso1()
    {
        if (Stats.favorDeDioses >= precioCastigoPiadoso1)
        {
            botonCastigoPiadoso1.SetActive(false);
            botonCastigoActivado = false;
            numBotonesMejoraAxctivos--;
            numCastigoPiadoso1++;
            mejoraCastigoPiadoso1 = true;
            TropaStats.magoAtaque = TropaStats.magoAtaque * 1.1f;
            Stats.favorDeDioses -= precioCastigoPiadoso1;
        }
    }

    public static bool mejoraSantaSentencia1;
    public bool botonSentenciaActivado = false;
    public static int numSantaSentencia1;
    public int precioSantaSentencia1 = 35;
    public GameObject botonSantaSentencia1;

    public void ActivarSantaSentencia1()
    {
        if (Stats.favorDeDioses >= precioSantaSentencia1)
        {
            botonSantaSentencia1.SetActive(false);
            botonCastigoActivado = false;
            numBotonesMejoraAxctivos--;
            numSantaSentencia1++;
            mejoraSantaSentencia1 = true;
            TropaStats.magoCriticoPorcentaje += 5f;
            Stats.favorDeDioses -= precioSantaSentencia1;
        }
    }

    public static bool mejoraClarividencia;
    public bool botonClarividenciaActivado = false;
    public static int numClarividencia;
    public int precioClarividencia = 60;
    public GameObject botonClarividencia;

    public void ActivarClarividencia()
    {
        if (Stats.favorDeDioses >= precioClarividencia)
        {
            botonClarividencia.SetActive(false);
            botonClarividenciaActivado = false;
            numBotonesMejoraAxctivos--;
            numClarividencia++;
            mejoraClarividencia = true;
            TropaStats.magoRango += TropaStats.magoRango * 0.1f;
            Stats.favorDeDioses -= precioClarividencia;           
        }
    }

    private int numBotonesMejoraAxctivos = 0;
    private void Update()
    {
        if (numBotonesMejoraAxctivos < 3)
        {
            Debug.Log("se ejecuta");
            RandomMejoraGlobal();
            return;
        }     
    }

    private int numRandom;
    public void RandomMejoraGlobal()
    {      
        numRandom = Random.Range(0,5); //el 5 no está incluido (por el culo te la hinco)
        
        if (numRandom == 0)
        {
            if (!botonBotinActivado)
            {
                botonBotinDivino1.SetActive(true);
                botonBotinActivado = true;
                numBotonesMejoraAxctivos++;
                Debug.Log("botin");
            }             
        }
        else if (numRandom == 1)
        {
            if (!botonCastigoActivado)
            {
                botonCastigoPiadoso1.SetActive(true);
                botonCastigoActivado = true;
                numBotonesMejoraAxctivos++;
                Debug.Log("castigo");
            }                      
        }
        else if (numRandom == 2)
        {
            if (numSantaSentencia1 < 10 && !botonSentenciaActivado)
            {
                botonSantaSentencia1.SetActive(true);
                botonSentenciaActivado = true;
                numBotonesMejoraAxctivos++;
                Debug.Log("sentencia");
            }          
        }
        else if (numRandom == 3)
        {
            if (numVivacidad1 < 5 && !botonVivacidadActivado)
            {
                botonVivacidad1.SetActive(true);
                botonVivacidadActivado = true;
                numBotonesMejoraAxctivos++;
                Debug.Log("vivacidad");
            }           
        }
        else if (numRandom == 4)
        {
            if (numClarividencia < 5 && !botonClarividenciaActivado)
            {
                botonClarividencia.SetActive(true);
                botonClarividenciaActivado = true;
                numBotonesMejoraAxctivos++;
                Debug.Log("clarividencia");
            }
        }
        return;
    }



    public Color hoverColor; //color cuando poner el cursor por encima   
    private SpriteRenderer sprite; //creamos la variable sprite para poder cambiarle el color al SpriteRenderer de la mina   
    private Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    private bool menuActivado = false;

    public GameObject menuTemplo;

    // Start is called before the first frame update
    void Start()
    {
        numBotonesMejoraAxctivos = 0;

        botonBotinActivado = false;
        botonCastigoActivado = false;
        botonSentenciaActivado = false;
        botonVivacidadActivado = false;
        botonClarividenciaActivado = false;

        numBotinDivino1 = 0;
        numCastigoPiadoso1 = 0;
        numSantaSentencia1 = 0;
        numVivacidad1 = 0;
        numClarividencia = 0;

        mejoraBotinDivino1 = false;
        mejoraCastigoPiadoso1 = false;
        mejoraSantaSentencia1 = false;
        mejoraVivacidad1 = false;
        mejoraClarividencia = false;

        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        colorInicial = sprite.color;
        RandomMejoraGlobal();
        RandomMejoraGlobal();
        RandomMejoraGlobal();
    }

    public void desactivarMenu()
    {
        menuActivado = false;
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado)
        {
            menuTemplo.SetActive(true);
            menuActivado = true;
            sprite.color = colorInicial;
        }       
    }

    //esta funcion se ejecuta al colocar el cursor sobre el nodo
    void OnMouseEnter()
    {
        if (!menuActivado)
        {
            sprite.color = hoverColor;
        }
    }

    //esta funcion se ejecuta al quitar el cursor de encima del nodo
    void OnMouseExit()
    {
        sprite.color = colorInicial;
    }
}
