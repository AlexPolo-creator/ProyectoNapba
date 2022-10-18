using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour
{
    public static bool poblacionMinaCero;

    public float velocidadMineros; //Cada cuantos segundos extraen oro.
    public float velocidadMinerosInicial = 5f;

    public int produccionOro; //Cantidad de oro que se produce por extracción
    public int produccionOroInicial = 5;

    public Color hoverColor; //color cuando poner el cursor por encima   
    private SpriteRenderer sprite; //creamos la variable sprite para poder cambiarle el color al SpriteRenderer de la mina   
    private Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    private bool menuActivado = false;

    public GameObject menuPoblacionMina;

    void Start()
    {
        //establezco los valores originales de produccionOro y velocidadMineros
        produccionOro = produccionOroInicial;
        velocidadMineros = velocidadMinerosInicial;

        //Uso una coroutina y no un InvokeRepeating para asi poder modificar en tiempo real lo que tarda en ejecutar el codigo, eso no se puede con un InvokeRepeating.
        StartCoroutine(SumarOro());

        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        colorInicial = sprite.color;
    }
    
    public IEnumerator SumarOro()
    {
        if (!poblacionMinaCero)
        {
            //esta sintaxis indica la cantidad de segundos reales (pero escalados) que tardara en ejecutar el resto del codigo
            yield return new WaitForSeconds(velocidadMineros);

            //suma al stat del oro la produccion de oro multiplidada por la poblacion trabajando en la mina
            Stats.oro += produccionOro * Stats.poblacionEnMina;

            //vuelve a iniciar la coroutina (bucle)
            StartCoroutine(SumarOro());
        }       
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado)
        {
            menuPoblacionMina.SetActive(true);
            menuActivado = true;
            sprite.color = colorInicial;
        }
        else if (menuActivado)
        {
            menuPoblacionMina.SetActive(false);
            menuActivado = false;
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
