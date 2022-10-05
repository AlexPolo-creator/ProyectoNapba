using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultivos : MonoBehaviour
{
    public static bool poblacionCultivoCero;

    public float velocidadGranjeros; //Cada cuantos segundos nace un nuevo aldeano cuando hay un solo granjero.
    public float velocidadGranjerosInicial = 300f; //velocidad por granjero inicial 

    float realVelocidad; //cuantos segundo tardan los granjeros asignados en procucir 1 de poblacion, esta dividido entre 10 para que la coroutina sea por intervalos y asi poder actualizarla en tiempo real

    public Color hoverColor; //color cuando poner el cursor por encima   
    private SpriteRenderer sprite; //creamos la variable sprite para poder cambiarle el color al SpriteRenderer de la mina   
    private Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    private bool menuActivado = false;

    public GameObject menuPoblacionCultivo;

    private void Update()
    {
        realVelocidad = velocidadGranjeros * 1 / Stats.poblacionEnCultivo / 10;
        
    }

    void Awake()
    {
        //establezco los valores originales de produccionOro y velocidadMineros        
        velocidadGranjeros = velocidadGranjerosInicial;

        realVelocidad = velocidadGranjeros * 1 / Stats.poblacionEnCultivo / 10;

        //Uso una coroutina y no un InvokeRepeating para asi poder modificar en tiempo real lo que tarda en ejecutar el codigo, eso no se puede con un InvokeRepeating.
        StartCoroutine(SumarPoblacion());

        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        colorInicial = sprite.color;
    }

    public IEnumerator SumarPoblacion()
    {
        if (!poblacionCultivoCero)
        {
            yield return new WaitForSeconds(0.01f); //bugfix

            //esta sintaxis indica la cantidad de segundos reales que tardara en ejecutar el resto del codigo, esta puesto 10 veces para que si el jugador cambia la cantidad de granjeros una vez empezada la coroutina no tenga que esperar a que se acabe la coroutina entera para ver la diferencia
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad);
            yield return new WaitForSeconds(realVelocidad - 0.01f);



            //suma al stat del oro la produccion de oro multiplidada por la poblacion trabajando en la mina
            Stats.poblacion++;

            //vuelve a iniciar la coroutina (bucle)
            StartCoroutine(SumarPoblacion());
        }
        
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado)
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