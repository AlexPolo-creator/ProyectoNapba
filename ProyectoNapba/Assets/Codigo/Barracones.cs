using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barracones : MonoBehaviour
{

    public Color hoverColor; //color
    private SpriteRenderer sprite; //creamos la variable sprite pa cuando poner el cursor por encima   ra poder cambiarle el color al SpriteRenderer de la mina   
    public Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    public static bool menuActivado = false;
    public static bool menuDesactivado = false;

    public GameObject getMenuBarracones;
    public static GameObject menuBarracones;

    public TextMeshProUGUI contadorOro;

    public TextMeshProUGUI precioArqueroTexto;
    public TextMeshProUGUI precioLanzadorHachasTexto;
    public TextMeshProUGUI precioLanceroTexto;

    private void Start()
    {
        menuBarracones = getMenuBarracones;
        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        sprite.color = colorInicial;

        precioArquero = precioArqueroInicial;
        precioLanzadorHachas = precioLanzadorHachasInicial;
        precioLancero = precioLanceroInicial;


        precioArqueroTexto.text = precioArquero.ToString();
        precioLanzadorHachasTexto.text = precioLanzadorHachas.ToString();
        precioLanceroTexto.text = precioLancero.ToString();
    }

    public void desactivarMenu()
    {
        menuActivado = false;

        Colegio.menuDesactivado = false;
        Templo.menuDesactivado = false;
        Herreria.menuDesactivado = false;
        Cultivos.menuDesactivado = false;
        Mina.menuDesactivado = false;
        Barrio.menuDesactivado = false;
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

    public int precioLanzadorHachasInicial;
    int precioLanzadorHachas;
    int numLanzadorHachasEntrenados;
    public void EntrenarLanzadorHachas()
    {
        if (Stats.oro >= precioLanzadorHachas)
        {
            Stats.lanzadoresHacha += 1;
            Stats.oro -= precioLanzadorHachas;
            numLanzadorHachasEntrenados++;
            precioLanzadorHachas = Mathf.RoundToInt(precioLanzadorHachas * SistemaDificultad.aumentoPrecioTropas);
            precioLanzadorHachasTexto.text = precioLanzadorHachas.ToString();
        }
    }

    public int precioLanceroInicial;
    int precioLancero;
    int numLanceroEntrenados;
    public void EntrenarLancero()
    {
        if (Stats.oro >= precioLancero)
        {
            Stats.lanceros += 1;
            Stats.oro -= precioLancero;
            numLanceroEntrenados++;
            precioLancero = Mathf.RoundToInt(precioLancero * SistemaDificultad.aumentoPrecioTropas);
            precioLanceroTexto.text = precioLancero.ToString();
        }
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado && !menuDesactivado)
        {
            Colegio.menuDesactivado = true;
            Templo.menuDesactivado = true;
            Herreria.menuDesactivado = true;
            Cultivos.menuDesactivado = true;
            Mina.menuDesactivado = true;
            Barrio.menuDesactivado = true;

            Templo.menuTemplo.SetActive(false);
            Colegio.menuColegio.SetActive(false);
            Herreria.menuHerreria.SetActive(false);
            Templo.menuActivado = false;
            Colegio.menuActivado = false;
            Herreria.menuActivado = false;

            menuBarracones.SetActive(true);
            menuActivado = true;
            sprite.color = colorInicial;
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
