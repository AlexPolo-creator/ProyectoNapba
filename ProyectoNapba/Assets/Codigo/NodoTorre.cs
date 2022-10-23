using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoTorre : MonoBehaviour
{
    //instanciamos el MenuConstruccion
    MenuConstrucion menuConstrucion;

    //color cuando poner el cursor por encima
    public Color hoverColor;

    //color cuando pones el cursor por encima pero no tienes dieros
    public Color noTieneDineroColor;


    [Header("Opcional")]
    public GameObject torre = null; //se debe dejar en null a menso que queramos que al empezar el juego ese nodo tenga una torre (opcional)

    //creamos la variable sprite para poder cambiarle el color al SpriteRenderer del nodo
    private SpriteRenderer sprite;

    //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer del nodo cuando quitemos el cursor de encima
    private Color colorInicial;

    private void Start()
    {
        //obtemos el componente SpriteRenderer del nodo
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color del nodo al comienzo
        colorInicial = sprite.color;

        //establecemos la instancia el MenuConstruccion
        menuConstrucion = MenuConstrucion.instance;
    }

    //devuelve la posicion del nodo para colocar la torre en ella
    public Vector3 ObtenerPosicionColocacionTorre ()
    {
        return transform.position;
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        //devolvemos este objeto para la funcion ColocarTorreEn del script MenuConstruccion
        menuConstrucion.ColocarTorreEn(this);              
    }

    //esta funcion se ejecuta al colocar el cursor sobre el nodo
    void OnMouseEnter()
    {
        

        //si tiene dinero sufieciente cambaimos el color a hoverColor, si no tiene sufiencte cambiamos el color a noTieneDineooColor
        if (menuConstrucion.tieneDineroParaTorre)
        {
            sprite.color = hoverColor;
        }else
        {
            sprite.color = noTieneDineroColor;
        }
        
    }

    //esta funcion se ejecuta al quitar el cursor de encima del nodo
    void OnMouseExit()
    {
        //si ya hay una torre desactivamos este objeto
        if (torre != null)
        {
            //desactiva el objeto
            gameObject.SetActive(false);
        }
        sprite.color = colorInicial;
    }
}
