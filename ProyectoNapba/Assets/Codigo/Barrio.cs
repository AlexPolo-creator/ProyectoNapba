using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barrio : MonoBehaviour
{
    public int precioPoblacionInicial;
    int precioPoblacion;
    public TextMeshProUGUI textoPrecio;

    public Color hoverColor; //color cuando poner el cursor por encima   
    private SpriteRenderer sprite; //creamos la variable sprite para poder cambiarle el color al SpriteRenderer de la mina   
    public Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    private bool menuActivado = false;
    public static bool menuDesactivado = false;

    public GameObject menuBarrio;

    void Start()
    {
        precioPoblacion = precioPoblacionInicial;
        textoPrecio.text = precioPoblacion.ToString();
        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        sprite.color = colorInicial;
    }

    public void ComprarPoblacion()
    {
        if (Stats.comida >= precioPoblacion)
        {
            Stats.poblacionLibre += 1;
            Stats.comida -= precioPoblacion;
            precioPoblacion = Mathf.RoundToInt(precioPoblacion * SistemaDificultad.aumentoPrecioTropas);
            textoPrecio.text = precioPoblacion.ToString();
        }
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado && !menuDesactivado)
        {
            

            menuBarrio.SetActive(true);
            menuActivado = true;
            sprite.color = colorInicial;
        }
        else if (menuActivado)
        {
            menuBarrio.SetActive(false);
            menuActivado = false;
        }
    }

    //esta funcion se ejecuta al colocar el cursor sobre el nodo
    void OnMouseEnter()
    {
        if (!menuActivado && !menuDesactivado)
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
