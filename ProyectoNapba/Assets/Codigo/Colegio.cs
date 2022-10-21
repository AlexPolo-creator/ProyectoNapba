using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Colegio : MonoBehaviour
{
    public Color hoverColor; //color
    private SpriteRenderer sprite; //creamos la variable sprite pa cuando poner el cursor por encima   ra poder cambiarle el color al SpriteRenderer de la mina   
    private Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    public static bool menuActivado = false;

    public GameObject getMenuColegio;
    public static GameObject menuColegio;

    public TextMeshProUGUI contadorFavor;

    public TextMeshProUGUI precioHechiceroTexto;
    public TextMeshProUGUI precioVerdugoTexto;
    public TextMeshProUGUI precioDruidaTexto;
    public TextMeshProUGUI precioInquisidorTexto;

    private void Start()
    {
        menuColegio = getMenuColegio;
        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        colorInicial = sprite.color;

        precioHechicero = precioHechiceroInicial;
        precioVerdugo = precioVerdugoInicial;
        precioDruida = precioDruidaInicial;
        precioInquisidor = precioInquisidorInicial;

        precioHechiceroTexto.text = precioHechicero.ToString();
        precioVerdugoTexto.text = precioVerdugo.ToString();
        precioDruidaTexto.text = precioDruida.ToString();
        precioInquisidorTexto.text = precioInquisidor.ToString();
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
            precioHechicero = Mathf.RoundToInt(precioHechicero * SistemaDificultad.aumentoPrecioTropas);
            precioHechiceroTexto.text = precioHechicero.ToString();
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
            precioVerdugo = Mathf.RoundToInt(precioVerdugo * SistemaDificultad.aumentoPrecioTropas);
            precioVerdugoTexto.text = precioVerdugo.ToString();
        }
    }

    public int precioDruidaInicial;
    int precioDruida;
    int numDruidasEntrenados;
    public void EntrenarDruida()
    {
        if (Stats.favorDeDioses >= precioDruida)
        {
            Stats.druidas += 1;
            Stats.favorDeDioses -= precioDruida;
            numDruidasEntrenados++;
            precioDruida = Mathf.RoundToInt(precioDruida * SistemaDificultad.aumentoPrecioTropas);
            precioDruidaTexto.text = precioDruida.ToString();
        }
    }

    public int precioInquisidorInicial;
    int precioInquisidor;
    int numInquisidoresEntrenados;
    public void EntrenarInquisidor()
    {
        if (Stats.favorDeDioses >= precioInquisidor)
        {
            Stats.inquisidores += 1;
            Stats.favorDeDioses -= precioInquisidor;
            numInquisidoresEntrenados++;
            precioInquisidor = Mathf.RoundToInt(precioInquisidor * SistemaDificultad.aumentoPrecioTropas);
            precioInquisidorTexto.text = precioInquisidor.ToString();
        }
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado)
        {
            Templo.menuTemplo.SetActive(false);
            Barracones.menuBarracones.SetActive(false);
            Herreria.menuHerreria.SetActive(false);
            Templo.menuActivado = false;
            Barracones.menuActivado = false;
            Herreria.menuActivado = false;

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
