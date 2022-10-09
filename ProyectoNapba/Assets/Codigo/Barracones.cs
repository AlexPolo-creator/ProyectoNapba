using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barracones : MonoBehaviour
{
    public Color hoverColor; //color
    private SpriteRenderer sprite; //creamos la variable sprite pa cuando poner el cursor por encima   ra poder cambiarle el color al SpriteRenderer de la mina   
    private Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    public static bool menuActivado = false;

    public GameObject menuColegio;
    public GameObject menuTemplo;
    public GameObject menuBarracones;

    public TextMeshProUGUI contadorOro;

    public TextMeshProUGUI precioArqueroTexto;

    private void Start()
    {
        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        colorInicial = sprite.color;

        precioArquero = precioArqueroInicial;
        

        precioArqueroTexto.text = precioArquero.ToString();
    }

    public void desactivarMenu()
    {
        menuActivado = false;
    }

    public int precioArqueroInicial;
    int precioArquero;
    int numArquerosEntrenados;
    public void EntrenarArquero()
    {
        if (Stats.oro >= precioArquero)
        {
            Stats.arqueros += 1;
            Stats.oro -= precioArquero;
            numArquerosEntrenados++;
            precioArquero = Mathf.RoundToInt(precioArquero * SistemaDificultad.aumentoPrecioTropas);
            precioArqueroTexto.text = precioArquero.ToString();
        }
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado)
        {
            menuTemplo.SetActive(false);
            menuColegio.SetActive(false);
            Templo.menuActivado = false;
            Colegio.menuActivado = false;
            menuBarracones.SetActive(true);
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
