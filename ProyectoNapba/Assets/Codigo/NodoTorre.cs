using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodoTorre : MonoBehaviour
{
    MenuConstrucion menuConstrucion;

    public Color hoverColor;

    private GameObject torre = null;

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
        if (menuConstrucion.ObtenerTorreAColocar() == null) return;

        if (torre = null)
        {
            Debug.Log("No se puede construir ahí pendejo!");
            return;
        }

        GameObject torreAColocar = MenuConstrucion.instance.ObtenerTorreAColocar();
        torre = (GameObject)Instantiate(torreAColocar, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    void OnMouseEnter()
    {
        if (menuConstrucion.ObtenerTorreAColocar() == null) return;
        Debug.Log("onMouseEnter");
        sprite.color = hoverColor;
    }
    void OnMouseExit()
    {
        sprite.color = colorInicial;
    }

}
