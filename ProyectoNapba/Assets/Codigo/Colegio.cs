using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colegio : MonoBehaviour
{
    public Color hoverColor; //color
    private SpriteRenderer sprite; //creamos la variable sprite pa cuando poner el cursor por encima   ra poder cambiarle el color al SpriteRenderer de la mina   
    private Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    public static bool menuActivado = false;

    public GameObject menuColegio;
    public GameObject menuTemplo;

    private void Start()
    {
        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        colorInicial = sprite.color;

        precioHechicero = precioHechiceroInicial;
        precioVerdugo = precioVerdugoInicial;

    }
    public void desactivarMenu()
    {
        menuActivado = false;
    }



    public int precioHechiceroInicial;
    int precioHechicero;
    int numHechicerosEntrenados;
    public void EntrenarHechicero()
    {
        if (Stats.favorDeDioses >= precioHechicero)
        {          
            Stats.hechiceros += 1;
            Stats.favorDeDioses -= precioHechicero;
            numHechicerosEntrenados++;
            precioHechicero = Mathf.RoundToInt(precioHechicero * 1.1f);
        }
    }

    public int precioVerdugoInicial;
    int precioVerdugo;
    int numVerdugosEntrenados;
    public void EntrenarVerdugo()
    {
        if (Stats.favorDeDioses >= precioVerdugo)
        {
            Stats.verdugos += 1;
            Stats.favorDeDioses -= precioVerdugo;
            numVerdugosEntrenados++;
            precioVerdugo = Mathf.RoundToInt(precioVerdugoInicial * 1.1f);
        }
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado)
        {
            menuTemplo.SetActive(false);
            Templo.menuActivado = false;
            menuColegio.SetActive(true);           
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
