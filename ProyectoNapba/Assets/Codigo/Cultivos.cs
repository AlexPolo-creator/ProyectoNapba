using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cultivos : MonoBehaviour
{
    public static bool poblacionCultivoCero;

    public GameObject popUpComida;
    TextMeshPro textoPopUp;

    public Transform popUpPosicion;

    public static float velocidadGranjeros; //Cada cuantos segundos nace un nuevo aldeano cuando hay un solo granjero.
    public float velocidadGranjerosInicial = 10f; //velocidad por granjero inicial 

    public static int produccionComida; //Cantidad de oro que se produce por extracci�n
    public int produccionComidaInicial = 1;

    public Color hoverColor; //color cuando poner el cursor por encima   
    private SpriteRenderer sprite; //creamos la variable sprite para poder cambiarle el color al SpriteRenderer de la mina   
    public Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    private bool menuActivado = false;
    public static bool menuDesactivado = false;

    public GameObject menuPoblacionCultivo;

    void Awake()
    {
        produccionComida = produccionComidaInicial;
        //establezco los valores originales de produccionOro y velocidadMineros        
        velocidadGranjeros = velocidadGranjerosInicial;

        //Uso una coroutina y no un InvokeRepeating para asi poder modificar en tiempo real lo que tarda en ejecutar el codigo, eso no se puede con un InvokeRepeating.
        StartCoroutine(SumarComida());

        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        sprite.color = colorInicial;
    }

    public IEnumerator SumarComida()
    {

        yield return new WaitForSeconds(velocidadGranjeros);

        //suma al stat del oro la produccion de oro multiplidada por la poblacion trabajando en la mina
        Stats.comida += produccionComida * Stats.poblacionEnCultivo;

        textoPopUp = popUpComida.GetComponent<TextMeshPro>();
        textoPopUp.SetText((produccionComida * Stats.poblacionEnCultivo).ToString());
        Instantiate(popUpComida, popUpPosicion.position, Quaternion.identity);
        //vuelve a iniciar la coroutina (bucle)
        StartCoroutine(SumarComida());
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado && !menuDesactivado)
        {
            

            menuPoblacionCultivo.SetActive(true);
            menuActivado = true;
            sprite.color = colorInicial;
        }
        else if (menuActivado)
        {
            menuPoblacionCultivo.SetActive(false);
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