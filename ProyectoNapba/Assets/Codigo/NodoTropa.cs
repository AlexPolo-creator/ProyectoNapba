using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoTropa : MonoBehaviour
{
    MenuConstrucion menuConstrucion;

    public Color hoverColor;

    private GameObject tropa = null;

    private SpriteRenderer sprite;
    private Color colorInicial;

    private void Start()
    {       
        sprite = GetComponent<SpriteRenderer>();
        colorInicial = sprite.color;

        menuConstrucion = MenuConstrucion.instance;
    }

    void OnMouseDown()
    {
        if (menuConstrucion.ObtenerTropaAColocar() == null) return;

        if (tropa = null)
        {
            Debug.Log("No se puede construir ahí pendejo!");
            return;
        }

        GameObject tropaAColocar = MenuConstrucion.instance.ObtenerTropaAColocar();
        tropa = (GameObject)Instantiate(tropaAColocar, transform.position, transform.rotation);
        
    }

    void OnMouseEnter()
    {
        if (menuConstrucion.ObtenerTropaAColocar() == null) return;

        sprite.color = hoverColor;
    }
    void OnMouseExit()
    {
        sprite.color = colorInicial;
    }

}        
    
