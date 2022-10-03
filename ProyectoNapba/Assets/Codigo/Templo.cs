using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templo : MonoBehaviour
{
    //Mejoras:
    public static bool mejoraBotinDivino1;
    public int precioBotinDivino1 = 75;
    public GameObject botonBotinDivino1;
    public void ActivarBotinDivino1()
    {
        if (Stats.favorDeDioses >= precioBotinDivino1)
        {
            mejoraBotinDivino1 = true;
            Stats.favorDeDioses -= precioBotinDivino1;
            botonBotinDivino1.SetActive(false);
        }
    }

    public static bool mejoraVivacidad1;
    public int precioVivacidad1 = 50;
    public GameObject botonVivacidad1;
    public void ActivarVivacidad1()
    {
        if (Stats.favorDeDioses >= precioVivacidad1)
        {
            mejoraVivacidad1 = true;
            TropaStats.magoVelocidadDeDisparo = TropaStats.magoVelocidadDeDisparo * 0.85f;
            Stats.favorDeDioses -= precioVivacidad1;
            botonVivacidad1.SetActive(false);
        }      
    }

    public static bool mejoraCastigoPiadoso1;
    public int precioCastigoPiadoso1 = 30;
    public GameObject botonCastigoPiadoso1;
    public void ActivarCastigoPiadoso1()
    {
        if (Stats.favorDeDioses >= precioCastigoPiadoso1)
        {
            mejoraCastigoPiadoso1 = true;
            TropaStats.magoAtaque = TropaStats.magoAtaque * 1.2f;
            Stats.favorDeDioses -= precioCastigoPiadoso1;
            botonCastigoPiadoso1.SetActive(false);
        }
    }

    public static bool mejoraSantaSentencia1;
    public int precioSantaSentencia1 = 35;
    public GameObject botonSantaSentencia1;
    public void ActivarSantaSentencia1()
    {
        if (Stats.favorDeDioses >= precioSantaSentencia1)
        {
            mejoraSantaSentencia1 = true;
            TropaStats.magoCriticoPorcentaje += 5f;
            Stats.favorDeDioses -= precioSantaSentencia1;
            botonSantaSentencia1.SetActive(false);
        }
    }



    public Color hoverColor; //color cuando poner el cursor por encima   
    private SpriteRenderer sprite; //creamos la variable sprite para poder cambiarle el color al SpriteRenderer de la mina   
    private Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    private bool menuActivado = false;

    public GameObject menuTemplo;

    // Start is called before the first frame update
    void Start()
    {
        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        colorInicial = sprite.color;
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
